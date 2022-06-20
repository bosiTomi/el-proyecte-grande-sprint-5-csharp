export default function Footer(props) {

    function loadJoke() {
        window.fetch(`Home/GetJoke`).then((response) => {
            response.json().then((data) => {
                let joke = document.getElementById("joke");
                joke.innerHTML = data["contents"]["jokes"]["joke"]["title"];
                joke.addEventListener("mouseover", () => {
                    joke.innerHTML = data["contents"]["jokes"]["joke"]["text"];
                });
                joke.addEventListener("mouseleave", () => {
                    joke.innerHTML = data["contents"]["jokes"]["joke"]["title"];
                });
            });
        });
    }
    loadJoke();
    return (
        <footer className="border-top footer text-muted">
            <div className="container" id="joke-container">
                &copy; 2022 - Delightful Daily Dose - <span>Credits </span>
                - Joke of the day: <marquee behavior="scroll" direction="left" id="joke"></marquee>
            </div>
        </footer>
    )
}