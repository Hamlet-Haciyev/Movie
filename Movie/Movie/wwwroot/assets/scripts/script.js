//const { error } = require("jquery");
//const { log } = require("util");

let preloader = document.querySelector(".preloader");
let barBtn = document.querySelector(".btn-collapse");
let menuCollapse = document.querySelector(".menu-collapse");
let backToTop = document.querySelector(".backtoTop");
let login = document.getElementById("login");
let overlayForm = document.querySelector(".overlay-form");
let instagram = document.getElementById("instagram-feed-demo");
let signUp = document.querySelector(".sign-up");
let closeBtn = document.querySelector("[data-close]");
let closeBtnSignup = document.querySelector("[data-close-signup]");
let overlayFormSignUp = document.querySelector(".overlay-form-signUp");
let forgetPasswordBtn = document.querySelector(".forgetPassword-Btn");
let CloseForgetPassword = document.querySelector("[data-close-forgetPassword]");
let overlayFormForgetPassword = document.querySelector(
    ".overlay-form-forgetPassword"
);
let forgetBtnn = document.querySelector(".send__email");
let loginBtnn = document.querySelector(".login-btn");
let postBtn = document.querySelector(".post-btn");
let result = document.querySelector("#result");
let commentRating = document.querySelector("#MovieComment_Rating")

window.onload = () => {
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

    viewAllMedia.addEventListener("click", (e) => {
        e.preventDefault();
        for (let a = 0; a < movieBtns.length; a++) {
            movieBtns[a].classList.remove("active");
        }
        movieBtns[1].classList.add("active");

        movieTabsOverview.classList.remove("show");
        relatedMovies.classList.remove("show");
        movieTabsMedia.classList.add("show");
    });
}

//$(document).ready(function () {

//    $(".test2").click(function () {
//        console.log($(this).data("id"))
//        let dataId = $(this).data("id");
//        if ($("#exampleInputEmail1").val() != "" &&
//            isEmail($("#exampleInputEmail1").val()) &&
//            $("#exampleFormControlTextarea1").val() != ""
//            && $("#exampleInputName1").val() != ""
//            ) {

//            $.ajax({
//                url: "Blog/Reply",
//                type: "POST",
//                datatype: "json",
//                data: ({
//                    //parentCommentid: $(this).data("id"),
//                    parentCommentid: $("#parentCommentid").val(),
//                    email: $("#exampleInputEmail1").val(),
//                    text: $("#exampleFormControlTextarea1").val(),
//                    name: $("#exampleInputName1").val(),
//                    blogId: $("#blogId").val()
//                }),
//                success: function (response) {
//                    console.log(response);
//                    if (response.isCheck) {
//                        console.log("Success");
//                        //toastr.success("Success message reply", { timeOut: 5000 })
//                        window.location.reload();
//                    }
//                    else {
//                        console.log("Error");
//                        toastr.error('Email movcud deyil');
//                    }
//                }
//                ,
//                error: function (error) {
//                    console.log("Error")
//                    console.log(error);
//                },
//                //complete: function () {
//                //    password = "";
//                //}
//            });
//        }

//    })
//})

//#region ReplyComment
//let replyComment = document.querySelectorAll(".replyComment");
//let cancelReply = document.querySelectorAll(".cancelReply");
//let BlogCommentParentCommentId = document.querySelector("#BlogComment_ParentCommentId");
//let wrappedCommentForm = document.querySelectorAll(".cancel_reply");
//let textReply = document.querySelector("#Text");
//window.onload = () => {
//    for (var i = 0; i < replyComment.length; i++) {
//        replyComment[i].addEventListener("click", (e) => {
//            console.log(e.target)

//            e.preventDefault();
//            //cancelReply.classList.add("showCancel");
//            wrappedCommentForm[i].classList.add("showCancel");
//            document.querySelector("#BlogComment_Text").focus();
//            BlogCommentParentCommentId.value = document.querySelector("#replyCommentId").value;
//        })
//    }
//    for (var i = 0; i < cancelReply.length; i++) {
//        cancelReply[i].addEventListener("click", (e) => {
//            e.preventDefault();
//            //cancelReply[i].classList.remove("showCancel");
//            wrappedCommentForm[i].children[0].children[0].classList.remove("showCancel");
//            BlogCommentParentCommentId.value = null;
//        })
//    }
//}
//#endregion

let isEmailTrue = function isEmail(email) {
    return /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test(email);
}
loginBtnn.addEventListener("click", (event) => {-
    event.preventDefault();
    let email = document.querySelector("#loginForm #VmLogin_Email").value;
    let password = document.querySelector("#loginForm #VmLogin_Password").value;

    if (email != "" && password != "") {
        $.ajax({
            url: location.origin + "/Account/Login",
            type: "POST",
            datatype: "json",
            data: ({
                email: email,
                password: password
            }),
            success: function (response) {
                console.log("Success");
                console.log(response);
                if (response.success) {
                    window.location = "https://localhost:44335/Home/Index"
                    //toastr.success("Success", { timeOut: 5000 })
                }
                else {
                    //result.innerHTML = response.message;
                    toastr.error('Email or password is wrong');
                    document.querySelector("#loginForm #VmLogin_Password").value = "";
                }
            }
            ,
            error: function (error) {
                console.log("Error")
                console.log(error);
            },
            //complete: function () {
            //    password = "";
            //}
        });
    }
})

forgetBtnn.addEventListener("click", () => {

    event.preventDefault();
    let email = document.querySelector(".overlay-form-forgetPassword__wrapped #emailForget").value;
    if (email != "") {
        $.ajax({
            url: "Account/ForgetPassword",
            type: "POST",
            datatype: "json",
            data: ({
                email: email
            }),
            success: function (response) {
                console.log(response);
                if (response.status) {
                    console.log("Success");
                    toastr.success(response.message, { timeOut: 5000 })
                    document.querySelector(".overlay-form-forgetPassword__wrapped [name='email']").value = "";
                    overlayFormForgetPassword.classList.remove("open");
                    document.body.style = "overflow:block;";
                }
                else {
                    console.log("Error");
                    toastr.error('Email movcud deyil');
                }
            }
            ,
            error: function (error) {
                console.log("Error")
                console.log(error);
            },
            //complete: function () {
            //    password = "";
            //}
        });
    }

})

window.addEventListener("load", () => {
  preloader.style.display = "none";
});
let moviePage = document.querySelector(".movie-page");
$(function () {
  const token =
    "IGQVJWN3hLNE92emNqd2tQSllMaGY5d0NQWUd3R1JLa3UxNmZATLTVZAWHB5TWYwOTRIQTZAQUXlLWjUtZAG9wZADBPTlpLeFBOaFAzOGdyeGVITmV0el9ucTk3S0RyVFJjeC02Mm9CZAnlybGVjVFpiajRpVAZDZD";
  const url =
    "https://graph.instagram.com/me/media?access_token=" +
    token +
    "&fields=media_url,media_type,caption,permalink,name";

  $.get(url).then(function (response) {
    console.log(response.data);
    const data = response.data;
    for (let i = 0; i < data.length; i++) {
      if (data[i].media_type == "IMAGE") {
        let instagramWrapped = document.createElement("div");
        instagramWrapped.classList.add("insta__content");

        let img = document.createElement("img");
        img.src = data[i].media_url;
        img.style = "max-width:100%";

        instagramWrapped.appendChild(img);
          instagram.appendChild(instagramWrapped);

        let element = document.querySelectorAll(".movie-page  .insta__content")
          for (var v = 0; v < element.length; v++) {
            element[v].style = "margin-bottom:30px"
        }

        instagramWrapped.addEventListener("click", () => {
          window.open(data[i].permalink);
        });
      } else if (data[i].media_type == "VIDEO") {
        let video = document.createElement("video");
        instagram.appendChild(video);
      }
    }
  });
});

signUp.addEventListener("click", (e) => {
  e.preventDefault();
  overlayForm.classList.remove("open");
  overlayFormSignUp.classList.add("open");
});

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
let viewAllMedia = document.querySelector(".view__all__media");
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
    document.body.style = "overflow:hidden;";
});

forgetPasswordBtn.addEventListener("click", (e) => {
    e.preventDefault();
    overlayForm.classList.remove("open");
    overlayFormSignUp.classList.remove("open");
    overlayFormForgetPassword.classList.add("open");
});
//closeBtn.addEventListener("click", (e) => {
//  e.preventDefault();
//  overlayForm.classList.remove("open");
//});
//closeBtnSignup.addEventListener("click", (e) => {
//  e.preventDefault();
//  overlayFormSignUp.classList.remove("open");
//});

closeBtn.addEventListener("click", (e) => {
    e.preventDefault();
    overlayForm.classList.remove("open");
    document.body.style = "overflow:visible;"

});
closeBtnSignup.addEventListener("click", (e) => {
    e.preventDefault();
    overlayFormSignUp.classList.remove("open");
});
CloseForgetPassword.addEventListener("click", (e) => {
    e.preventDefault();
    overlayFormForgetPassword.classList.remove("open");
});

window.addEventListener("click", (e) => {
  if (e.target.classList.contains("open")) {
    overlayForm.classList.remove("open");
      overlayFormSignUp.classList.remove("open");
      overlayFormForgetPassword.classList.remove("open");
      document.body.style = "overflow:visible;"
  }
});
window.addEventListener("scroll", (e) => {
  if (overlayForm.classList.contains("open")) {
    // disableScroll();
    console.log(document.documentElement.clientHeight);
    document.documentElement.clie;
    document.documentElement.clientHeight = 700;
  } else {
    // enableScroll();
  }
});

//#region Rating
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
    let v = 0;
    for (let b = 0; b < stars.length; b++) {
        stars[b].classList.remove("voted");
    }

    for (let a = 0; a <= i; a++) {
        stars[a].classList.add("voted");
        commentRating.value = ++v;
    }
  });
}
//#endregion

