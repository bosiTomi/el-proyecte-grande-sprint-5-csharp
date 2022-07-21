﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Delightful_Daily_Dose.Helpers;
using Delightful_Daily_Dose.Models;
using Delightful_Daily_Dose.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Delightful_Daily_Dose.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private IStoryRepository storyRepository;
        private IMapper mapper;

        public StoriesController(IStoryRepository storyRepository, IMapper mapper)
        {
            this.storyRepository = storyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StoryDetailViewModel> GetStories()
        {
            var stories = storyRepository.GetAll();
            return stories.Select(story => mapper.Map<StoryDetailViewModel>(story)).ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<StoryDetailViewModel> GetStoryDetails(string id)
        {
            var story = storyRepository.GetSingle(story => story.Id == id, story => story.Owner);
            return mapper.Map<StoryDetailViewModel>(story);
        }

        [HttpPost]
        public ActionResult<StoryCreationViewModel> Post([FromBody] UpdateStoryViewModel model)
        {
            var ownerId = HttpContext.User.Identity.Name;
            var creationTime = ((DateTimeOffset) DateTime.Now).ToUnixTimeSeconds();
            var storyId = Guid.NewGuid().ToString();
            var story = new UserStory
            {
                Id = storyId,
                Title = model.Title,
                Content = model.Content,
                Tag = model.Tag,
                CreationTime = creationTime,
                LastEditTime = creationTime,
                OwnerId = ownerId,
                PublishTime = creationTime
            };
            storyRepository.Add(story);
            storyRepository.Commit();

            return new StoryCreationViewModel
            {
                StoryId = storyId
            };
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(string id, [FromBody] UpdateStoryViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ownerId = HttpContext.User.Identity.Name;
            if (!storyRepository.IsOwner(id, ownerId)) return Forbid("You are not the owner of this story");

            var newStory = storyRepository.GetSingle(id);
            newStory.Title = model.Title;
            newStory.LastEditTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            newStory.Tag = model.Tag;
            newStory.Content = model.Content;

            storyRepository.Update(newStory);
            storyRepository.Commit();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var ownerId = HttpContext.User.Identity.Name;
            if (!storyRepository.IsOwner(id, ownerId)) return Forbid("You are not the owner of this story");

            storyRepository.DeleteWhere(story => story.Id == id);
            storyRepository.Commit();

            return NoContent();
        }
    }
}
