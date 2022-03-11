//const { error } = require("jquery");
//const { Url } = require("../plugins/custom/uppy/uppy.bundle5883");

$(document).ready(function () {
    //$('.select2').select2();
    //$('#Description').summernote(
    //    {
    //        height: 300
    //    }
    //);
    $(".deleteMovie").click(function (e) {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                swalWithBootstrapButtons.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Cancelled',
                    'Your imaginary file is safe :)',
                    'error'
                )
            }
        })
    })
   
});

//let logoFile = document.getElementById("LogoFile");
//let imageInputWrapper = document.querySelector(".image-input-wrapper")
//let Dataremove = document.querySelector("[data-action='remove']")
//let imgFile = document.getElementById("ImageFile");
//let videoFile = document.getElementById("VideoFile");
//let blogBgImage = document.querySelector(".blog-bg-image");
//let bgImageMovie = document.querySelector(".bg-image-movie");
//if (logoFile) {
//    logoFile.addEventListener("change", (e) => {
//        logoChange();
//    })
//    let logoChange = () => {
//        let file = [...logoFile.files];
//        let imagefile = file[0];

//        var fr = new FileReader();

//        fr.readAsDataURL(imagefile);

//        fr.onloadend = () => {
//            imageInputWrapper.style.backgroundImage = "url(" + fr.result + ")";
//        }
//        Dataremove.style.display = "block !important";
//    }

//    Dataremove.addEventListener("click", (e) => {
//        e.preventDefault();
//        imageInputWrapper.style.backgroundImage = "none";
//    })
//}

//if (imgFile) {
//    imgFile.addEventListener("change", (e) => {
//        imageChange();
//    })
//    let imageChange = () => {
//        let file = [...imgFile.files];
//        let imagefile = file[0];

//        var fr = new FileReader();

//        fr.readAsDataURL(imagefile);

//        fr.onloadend = () => {
//            bgImageMovie.style.backgroundImage = "url(" + fr.result + ")";
//        }
//        Dataremove.style.display = "block !important";
//    }
//    Dataremove.addEventListener("click", (e) => {
//        e.preventDefault();
//        imageInputWrapper.style.backgroundImage = "none";
//    })
//}


//if (videoFile) {
//    videoFile.addEventListener("change", (e) => {
//        videoChange();
//    })
//    let videoChange = () => {
//        let file = [...videoFile.files];
//        let imagefile = file[0];

//        var fr = new FileReader();

//        fr.readAsDataURL(imagefile);

//        fr.onloadend = () => {
//            iframeVideoCheck.href = fr.result;
//        }
//        Dataremove.style.display = "block !important";
//    }
//    Dataremove.addEventListener("click", (e) => {
//        e.preventDefault();
//        imageInputWrapper.style.backgroundImage = "none";
//    })
//}

