$(document).ready(function () {
    async function getpass() {
        let myObject = await fetch("../api/PassGen");
        let myText = await myObject.text();
        document.getElementById("passvalue").value = myText;
    
        var color = testPasswordStrength(myText);
    
        styleStrengthLine(color, myText);
    }
    // Calling that async function
    getpass();

    // hide/show password
    $(".icon-wrapper").click(function () {
        getpass();
    });

    // strength validation on keyup-event
    $("#passvalue").on("keyup", function () {
        var val = $(this).val(),
            color = testPasswordStrength(val);

        styleStrengthLine(color, val);
    });

    // check password strength
    function testPasswordStrength(value) {
        var strongRegex = new RegExp(
            '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[=/\()%ยง!@#$%^&*])(?=.{8,})'
        ),
            mediumRegex = new RegExp(
                '^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})'
            );

        if (strongRegex.test(value)) {
            return "green";
        } else if (mediumRegex.test(value)) {
            return "orange";
        } else {
            return "red";
        }
    }

    function styleStrengthLine(color, value) {
        $(".line")
            .removeClass("bg-red bg-orange bg-green")
            .addClass("bg-transparent");

        if (value) {

            if (color === "red") {
                $(".line:nth-child(1)")
                    .removeClass("bg-transparent")
                    .addClass("bg-red");
            } else if (color === "orange") {
                $(".line:not(:last-of-type)")
                    .removeClass("bg-transparent")
                    .addClass("bg-orange");
            } else if (color === "green") {
                $(".line")
                    .removeClass("bg-transparent")
                    .addClass("bg-green");
            }
        }
    }

});
