$(document).ready(function () {
    loadData();
});


function loadData() {
    $.ajax({
        url: "/Home/GetBoatList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result)
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.boatName + '</td>';
                html += '<td>' + item.hourlyPrice + '</td>';
              
                  html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });


}

function Add() {

    var res = validate();
    if (res == false) {
        return false;
    } 
    var boat = {

        ID: null,
        BoatName: $('#BoatName').val(),
        HourlyPrice: $('#HPrice').val(),
     

    };
    console.log(custObj);
    $.ajax({      

        url: '/Home/AddBoat',
        data: boat,
        type: "POST",      
        success: function (result) {
            console.log(result);
            $('#myModal').modal('hide');
            loadData();
            
            alert(result.message);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function clearTextBox() {
    $('#BoatID').val("");
    $('#BoatName').val("");
    $('#HPrice').val("");
    
  
    $('#BoatName').css('border-color', 'lightgrey');
    $('#HPrice').css('border-color', 'lightgrey');
 
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#BoatName').val().trim() == "") {
        $('#BoatName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#BoatName').css('border-color', 'lightgrey');
    }
    if ($('#HPrice').val().trim() == "") {
        $('#HPrice').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#HPrice').css('border-color', 'lightgrey');
    }
    
    
    return isValid;
}

