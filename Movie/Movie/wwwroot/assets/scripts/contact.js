
let isNull2 = $(".trialForm input")[0];
let contactInputs = $(".trialForm input");
let trialError = $(".trialError");
if (isNull2 != null || isNull2 != undefined) {

    for (let i = 0; i < contactInputs.length; i++) {
        contactInputs[i].addEventListener("focusout", function (e) {

            if (contactInputs[i].value == "") {
                trialError[i].style.display = "block";
            }


        })
        contactInputs[i].addEventListener("input", function (e) {
            if (contactInputs[i].value != "") {
                trialError[i].style.display = "none";
            }
        })


    }

    let trialTextArea = $("#trialTextArea")[0];
    let trialError2 = $(".trialError")[4]

    trialTextArea.addEventListener("focusout", function (e) {
        if (trialTextArea.value == "") {
            trialError2.style.display = "block";
        }
    })

    trialTextArea.addEventListener("input", function (e) {
        if (trialTextArea.value != "") {
            trialError2.style.display = "none";
        }
    })


    let submitBtn = $("#trialBtn");

    submitBtn[0].addEventListener("click", function (e) {
        e.preventDefault();
        if (trialTextArea.value == "" || contactInputs[0].value == "" || contactInputs[1].value == "" || contactInputs[2].value == "" || contactInputs[3].value == "") {
            $(".trialErrorSubmit")[0].style.display = "block"
            for (let i = 0; i < contactInputs.length; i++) {
                if (contactInputs[i].value == "") {
                    trialError[i].style.display = "block";
                }

            }
            if (trialTextArea.value == "") {
                trialError[4].style.display = "block"
            }

            $(".trial-form")[0].classList.add("animatedTrial");
            $(".trial-form")[0].addEventListener("animationend", function (e) {
                $(".trial-form")[0].classList.remove("animatedTrial");
            })

        } else {
            $(".trialErrorSubmit")[0].style.display = "none"
            for (let i = 0; i < contactInputs.length; i++) {
                contactInputs[i].value = ""
                contactInputs[i].disabled = true;

            }
            trialTextArea.value = ""
            trialTextArea.disabled = true;

            $(".submitSuccess")[0].style.display = "block";
            submitBtn[0].disabled = true;
            submitBtn[0].style.cursor = "default"
            $(".submitSuccess")[0].classList.add("submitSuccessAnim");
        }


    })
}
