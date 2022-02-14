$(document).ready(function () {
    $('.select2').select2();
    $('#Description').summernote(
        {
            height: 300
        }
    );
});

let logoFile = document.getElementById("LogoFile");
let imageInputWrapper = document.querySelector(".image-input-wrapper")
let Dataremove = document.querySelector("[data-action='remove']")
let imgFile = document.getElementById("ImageFile"); 
let videoFile = document.getElementById("VideoFile");
let blogBgImage = document.querySelector(".blog-bg-image");
let iframeVideoCheck = document.querySelector(".iframe-video-check");

if (logoFile) {
    logoFile.addEventListener("change", (e) => {
        logoChange();
    })
    let logoChange = () => {
        let file = [...logoFile.files];
        let imagefile = file[0];

        var fr = new FileReader();

        fr.readAsDataURL(imagefile);

        fr.onloadend = () => {
            imageInputWrapper.style.backgroundImage = "url(" + fr.result + ")";
        }
        Dataremove.style.display = "block !important";
    }

    Dataremove.addEventListener("click", (e) => {
        e.preventDefault();
        imageInputWrapper.style.backgroundImage = "none";
    })
}

if (imgFile) {
    imgFile.addEventListener("change", (e) => {
        imageChange();
    })
    let imageChange = () => {
        let file = [...imgFile.files];
        let imagefile = file[0];

        var fr = new FileReader();

        fr.readAsDataURL(imagefile);

        fr.onloadend = () => {
            blogBgImage.style.backgroundImage = "url(" + fr.result + ")";
        }
        Dataremove.style.display = "block !important";
    }
    Dataremove.addEventListener("click", (e) => {
        e.preventDefault();
        imageInputWrapper.style.backgroundImage = "none";
    })
}


if (videoFile) {
    videoFile.addEventListener("change", (e) => {
        videoChange();
    })
    let videoChange = () => {
        let file = [...videoFile.files];
        let imagefile = file[0];

        var fr = new FileReader();

        fr.readAsDataURL(imagefile);

        fr.onloadend = () => {
            iframeVideoCheck.href = fr.result;
        }
        Dataremove.style.display = "block !important";
    }
    Dataremove.addEventListener("click", (e) => {
        e.preventDefault();
        imageInputWrapper.style.backgroundImage = "none";
    })
}

