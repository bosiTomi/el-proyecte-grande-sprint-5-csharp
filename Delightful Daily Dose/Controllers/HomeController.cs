﻿using Delightful_Daily_Dose.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Delightful_Daily_Dose.Helpers;
using Delightful_Daily_Dose.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Delightful_Daily_Dose.Controllers
{
    [Authorize]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiHelper _apiHelper;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, ApiHelper apiHelper, IUserRepository userRepository)
        {
            _logger = logger;
            _apiHelper = apiHelper;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [Route("/[controller]")]
        public async Task<List<News>> Index()
        {
            string ApiUrl = "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=world";
            List<News> news = await _apiHelper.GetNews(ApiUrl);
            return news;

        }

        [Authorize(Policy = "AdminOnly")]
        [Route("/[controller]/users")]
        public IEnumerable<User> Users()
        {
            return _userRepository.GetAllUsers();
        }

        [AllowAnonymous]
        [Route("/[controller]/business")]
        public async Task<List<News>> Business()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=business";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/culinary")]
        public async Task<List<News>> Culinary()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=food";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/domestic")]
        public async Task<List<News>> Domestic()
        {
            string ApiUrl = "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&country=hu";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/economics")]
        public async Task<List<News>> Economics()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=economics";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/entertainment")]
        public async Task<List<News>> Entertainment()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=entertainment";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/environment")]
        public async Task<List<News>> Environment()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=environment";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/foreign")]
        public async Task<List<News>> Foreign()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&category=world";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/fresh")]
        public async Task<List<News>> Fresh()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=business,health,politics,top,world";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/health")]
        public async Task<List<News>> Health()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=health";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/most_viewed")]
        public async Task<List<News>> MostViewed()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=top";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/politics")]
        public async Task<List<News>> Politics()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=politics";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/sport")]
        public async Task<List<News>> Sport()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7623a07d5aec61d454d6ab40deb859282e19&language=en&category=sports";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/techworld")]
        public async Task<List<News>> TechWorld()
        {
            string ApiUrl =
                "https://newsdata.io/api/1/news?apikey=pub_7682df2f939752b8d025143691aa2d432601&language=en&category=science,technology";
            List <News> news = await _apiHelper.GetNews(ApiUrl);
            return news;
        }

        [AllowAnonymous]
        [Route("/[controller]/GetJoke")]
        public async Task<string> GetJoke()
        {
            string apiUrl = "https://api.chucknorris.io/jokes/random";
            return await _apiHelper.GetApi(apiUrl);
        }

        [AllowAnonymous]
        [Route("/[controller]/GetDog")]
        public async Task<string> GetDog()
        {
            string apiUrl = "https://dog.ceo/api/breeds/image/random";
            return await _apiHelper.GetApi(apiUrl);
        }

        [AllowAnonymous]
        [Route("/[controller]/GetNameDay")]
        public async Task<string> GetNameDay()
        {
            string apiUrl = "https://api.nevnapok.eu/ma";
            return await _apiHelper.GetApi(apiUrl);

            //return @"{ ""06-08"": [""Aglent"", ""Ágnes"", ""Agnéta"", ""Elga""]}";

        }

        [AllowAnonymous]
        [Route("/[controller]/GetWeather")]
        public async Task<string> GetWeather()
        {
            string apiUrl =
                "https://api.openweathermap.org/data/2.5/weather?q=Budapest,hu&units=metric&appid=104d168e3001f454894090545b535f79";
            return await _apiHelper.GetApi(apiUrl);


            //return @"{ ""coord"":{ ""lon"":19.0399,""lat"":47.498},""weather"":[{ ""id"":803,""main"":""Clouds"",""description"":""broken clouds"",""icon"":""04d""}],""base"":""stations"",""main"":{ ""temp"":25.8,""feels_like"":26.19,""temp_min"":25.29,""temp_max"":26.02,""pressure"":1008,""humidity"":67},""visibility"":10000,""wind"":{ ""speed"":3.09,""deg"":130},""clouds"":{ ""all"":75},""dt"":1654681821,""sys"":{ ""type"":2,""id"":2009661,""country"":""HU"",""sunrise"":1654656451,""sunset"":1654713507},""timezone"":7200,""id"":3054643,""name"":""Budapest"",""cod"":200}";

        }

        [AllowAnonymous]
        [Route("/[controller]/GetExchangeRate")]
        public async Task<string> GetExchangeRate(string from)
        {
            //string apiUrl =
            //    $"https://api.apilayer.com/exchangerates_data/convert?to=HUF&from={from}&amount=1&apikey=JS7qpwEXHPVbtntwU7H69R1jHnAHj7AA";
            //return await _apiHelper.GetApi(apiUrl);

            return @"            {
                ""success"": true,
                ""query"": {
                    ""from"": ""EUR"",
                    ""to"": ""HUF"",
                    ""amount"": 1
                },
                ""info"": {
                    ""timestamp"": 1654682403,
                    ""rate"": 415.555771
                },
                ""date"": ""2022-06-08"",
                ""result"": 415.555771
            }";
        }

        [Authorize(Policy = "User")]
        [Route("/[controller]/GetTopBoxOffice")]
        public async Task<string> GetTopBoxOffice()
        {
            string apiUrl = "https://imdb-api.com/en/API/BoxOffice/k_isz4vrmq";
            return await _apiHelper.GetApi(apiUrl);
        }

        [Authorize(Policy = "User")]
        [Route("/[controller]/GetTopImdbTvShows")]
        public async Task<string> GetTopImdbTvShows()
        {
            string apiUrl = "https://imdb-api.com/en/API/Top250TVs/k_isz4vrmq";
            return await _apiHelper.GetApi(apiUrl);
        }

        [Authorize(Policy = "User")]
        [Route("/[controller]/GetComingSoonToBoxOffice")]
        public async Task<string> GetComingSoonToBoxOffice()
        {
            string apiUrl = "https://imdb-api.com/en/API/ComingSoon/k_isz4vrmq";
            return await _apiHelper.GetApi(apiUrl);
        }

        [Authorize(Policy = "User")]
        [Route("/[controller]/GetYoutubeMostViewed")]
        public async Task<string> GetYoutubeMostViewed()
        {
            string apiUrl = "https://youtube.googleapis.com/youtube/v3/videos?part=snippet&chart=mostPopular&maxResults=25&regionCode=HU&videoCategoryId=0&key=AIzaSyD61k1tx-iwfoKtmhIHGmAm4xq3_Q8Oy5I";
            return await _apiHelper.GetApi(apiUrl);
        }

        [Authorize(Policy = "AdminOnly")]
        [Route("/[controller]/history")]
        public IEnumerable<News> GetNewsHistory()
        {
            return _apiHelper.GetNewsFromDb();
        }
    }
}