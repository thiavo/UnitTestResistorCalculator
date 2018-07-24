
$(document).ready(function () {

    //load select controls' background color on page load
    $("select").each(function () {
        setBackgroundColor($(this));
    });

    //load select control items' background color on page load
    $("select option").each(function () {
        setBackgroundColor($(this));
    });

    //Used to set background color of select control and its items
    function setBackgroundColor(object) {
        var color = "black";

        //Switch statement to change the band color in resistor figure when its respective select control's select value changes
        switch (object.attr('id')) {
            case "drpFirstBand":
                SetFigureBandColor($("#divFirstBand"), object);
                break;
            case "drpSecondBand":
                SetFigureBandColor($("#divSecondBand"), object);
                break;
            case "drpThirdBand":
                SetFigureBandColor($("#divThirdBand"), object);
                break;
            case "drpFourthBand":
                SetFigureBandColor($("#divFourthBand"), object);
                break;                
            default: 
        }

        // Set background color of select items 
        if (object.val() != '') {

            object.css('background-color', object.val());

            switch (object.val()) {
                case "black":
                    color = "white";
                    break;
                case "red":
                    color = "white";
                    break;
                case "green":
                    color = "white";
                    break;
                case "brown":
                    color = "white";
                    break;
                case "blue":
                    color = "white";
                    break;
                case "gray":
                    color = "white";
                    break;
                default:

            }
            object.css('color', color);
        }
    }

    //set background colors of bands in resistor figure
    function SetFigureBandColor(figureObject,selectObj)
    {
        var className = figureObject.attr('class').split(' ');
        figureObject.addClass(selectObj.val()).removeClass(className[1]);
    }

    //triggers whenever a new item is selected from band select controls 
    $("select").change(function () {

        setBackgroundColor($(this));


        var obj = {
        'bandAColor':$('#drpFirstBand').val(), 
        'bandBColor':$('#drpSecondBand').val(), 
        'bandCColor': $('#drpThirdBand').val(),
        'bandDColor': $('#drpFourthBand').val()
        };

        //var param = JSON.stringify(obj);



        // this ajax call returns the minimum and maximum resistance value as ajax JSON response.
        $.ajax({
            type:"POST",
            url: "/Home/getResistanceValue",
            cache:false,
            dataType: "json",
            data:obj,
            success: function (result) {
                //if error
                if (result.error != undefined) {                  
                    $("#divError").html(result.error);
                }
                else {
                    $("#divError").empty();
                    $("#txtMinimumResistance").val(result.min);
                    $("#txtMaximumResistance").val(result.max);
                    $("#txtResistorValue").val(result.main);
                }
            }
        });
    });

})