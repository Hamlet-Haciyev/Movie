let barBtn = document.querySelector(".btn-collapse");
let menuCollapse = document.querySelector(".menu-collapse");
let backToTop = document.querySelector(".backtoTop");
let login = document.getElementById("login");
let overlayForm = document.querySelector(".overlay-form");
//#region Celebrities
let celebritieBtns = document.querySelectorAll(
  ".celebritie__tabs-title ul li a"
);
let biography = document.querySelector(".biography");
let filmography = document.querySelector(".filmography");
//#endregion

//#region Movies
let movieBtns = document.querySelectorAll(".movie-tab ul li a");
let movieTabsOverview = document.querySelector(
  ".movie__tabs__content__overview"
);
let movieTabsMedia = document.querySelector(".movie__tabs__content__media");
let allReviewsBtn = document.querySelector(
  ".movie__reviews .movie__review__title a"
);
let relatedMovies = document.querySelector(
  ".movie__tabs__content__related__movies"
);
let allreviewsContent = document.querySelector(
  ".movie__tabs__content__all__reviews"
);
//#endregion

barBtn.addEventListener("click", (e) => {
  e.preventDefault();
  menuCollapse.classList.toggle("show");
});

backToTop.addEventListener("click", (e) => {
  e.preventDefault();
  window.scrollTo(0, 0);
});

login.addEventListener("click", (e) => {
  e.preventDefault();
  overlayForm.classList.add("open");
});

window.addEventListener("click", (e) => {
  if (e.target.classList.contains("open")) {
    overlayForm.classList.remove("open");
  }
});

window.addEventListener("scroll", (e) => {
  if (overlayForm.classList.contains("open")) {
    window.scrollTo(0, 0);
  }
});

for (let i = 0; i < celebritieBtns.length; i++) {
  celebritieBtns[i].addEventListener("click", (e) => {
    e.preventDefault();
    for (let a = 0; a < celebritieBtns.length; a++) {
      celebritieBtns[a].classList.remove("active");
    }
    celebritieBtns[i].classList.add("active");

    if (celebritieBtns[i].textContent.toLowerCase() == "filmography") {
      biography.classList.remove("show");
      filmography.classList.add("show");
    } else {
      filmography.classList.remove("show");
      biography.classList.add("show");
    }
  });
}
for (let i = 0; i < movieBtns.length; i++) {
  movieBtns[i].addEventListener("click", (e) => {
    e.preventDefault();
    for (let a = 0; a < movieBtns.length; a++) {
      movieBtns[a].classList.remove("active");
    }
    allreviewsContent.classList.remove("show");

    movieBtns[i].classList.add("active");

    if (movieBtns[i].textContent.toLowerCase() == "media") {
      movieTabsMedia.classList.add("show");
      movieTabsOverview.classList.remove("show");
      relatedMovies.classList.remove("show");
    } else if (movieBtns[i].textContent.toLowerCase() == "related movie") {
      relatedMovies.classList.add("show");
      movieTabsMedia.classList.remove("show");
      movieTabsOverview.classList.remove("show");
    } else {
      movieTabsOverview.classList.add("show");
      movieTabsMedia.classList.remove("show");
      relatedMovies.classList.remove("show");
    }
  });
}
allReviewsBtn.addEventListener("click", (e) => {
  e.preventDefault();
  for (let a = 0; a < movieBtns.length; a++) {
    movieBtns[a].classList.remove("active");
  }
  movieTabsOverview.classList.remove("show");
  movieTabsMedia.classList.remove("show");
  relatedMovies.classList.remove("show");
  allreviewsContent.classList.add("show");
});

let instagram = document.getElementById("instagram-feed-demo");
$(function () {
  const url =
    "https://graph.instagram.com/me/media?access_token=" +
    token +
    "&fields=media_url,media_type,caption,permalink";

  $.get(url).then(function (response) {
    console.log(response.data);
    const data = response.data;
    for (let i = 0; i < data.length; i++) {
      if (data[i].media_type == "IMAGE") {
        let img = document.createElement("img");
        img.src = data[i].media_url;
        img.style.width = "150px";
        // img.onclick = window.open(data[i].permalink);
        instagram.appendChild(img);
      } else if (data[i].media_type == "VIDEO") {
        let video = document.createElement("video");
        instagram.appendChild(video);
      }
    }
  });
});

//#region Js Stackoverflow

// var keys = { 37: 1, 38: 1, 39: 1, 40: 1 };

// function preventDefault(e) {
//   e.preventDefault();
// }

// function preventDefaultForScrollKeys(e) {
//   if (keys[e.keyCode]) {
//     preventDefault(e);
//     return false;
//   }
// }

// // modern Chrome requires { passive: false } when adding event
// var supportsPassive = false;
// try {
//   window.addEventListener(
//     "test",
//     null,
//     Object.defineProperty({}, "passive", {
//       get: function () {
//         supportsPassive = true;
//       },
//     })
//   );
// } catch (e) {}

// var wheelOpt = supportsPassive ? { passive: false } : false;
// var wheelEvent =
//   "onwheel" in document.createElement("div") ? "wheel" : "mousewheel";

// // call this to Disable
// function disableScroll() {
//   window.addEventListener("scroll", preventDefault, false); // older FF
//   window.addEventListener(wheelEvent, preventDefault, wheelOpt); // modern desktop
//   window.addEventListener("touchmove", preventDefault, wheelOpt); // mobile
//   window.addEventListener("keydown", preventDefaultForScrollKeys, false);
// }

// // call this to Enable
// function enableScroll() {
//   window.removeEventListener("scroll", preventDefault, false);
//   window.removeEventListener(wheelEvent, preventDefault, wheelOpt);
//   window.removeEventListener("touchmove", preventDefault, wheelOpt);
//   window.removeEventListener("keydown", preventDefaultForScrollKeys, false);
// }

//#endregion

let stars = document.querySelectorAll(".cm__rating__stars span");
let cmRatingElement = document.querySelector(".cm__rating__stars");
for (let i = 0; i <= stars.length; i++) {
  stars[i].addEventListener("mouseover", (e) => {
    for (let r = 0; r <= i; r++) {
      stars[r].classList.add("over");
    }
  });
  stars[i].addEventListener("mouseout", (e) => {
    for (let r = 0; r <= i; r++) {
      stars[r].classList.remove("over");
    }
  });

  stars[i].addEventListener("click", (e) => {
    for (let b = 0; b < stars.length; b++) {
      stars[b].classList.remove("voted");
    }

    for (let a = 0; a <= i; a++) {
      stars[a].classList.add("voted");
    }
  });
}
