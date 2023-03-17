var host = "https://localhost:44395/"

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

$(document).ready(function () {



    const today = new Date();
    const yyyy = today.getFullYear();
    let mm = today.getMonth() + 1;
    let dd = today.getDate();

    if (dd < 10) dd = '0' + dd;
    if (mm < 10) mm = '0' + mm;

    const formattedToday = dd + '/' + mm + '/' + yyyy;

    document.getElementById('to').valueAsDate = new Date();
    document.getElementById('Invoices_Date').valueAsDate = new Date();

    $("#sub_id").on("keyup", function () {

        //  if (this.value.length > 1 ) {
        $.ajax(`${host}Subscribtion/getSubscriberBySusbscribtionId?Subscription_No=${this.value}`,
            {
                type: 'GET',
                dataType: 'json',
                success: function (data, status, xhr) {
                    if (data != null) {
  

                        $("#unit_no").val(data.subscription_File_Unit_No)
                        $("#prev").val(data.subscription_File_Last_Reading_Meter)
                        $("#id").val(data.subscriber.subscriber_File_Id)
                        $("#name").val(data.subscriber.subscriber_File_Name)

                        $("#rreal").val(data.rreal_Estate_Types_Code)

                        if (data.subscription_File_Is_There_Sanitation == true) {
                            $("#san").val("نعم");
                            $("#san").attr("data-isSan", data.subscription_File_Is_There_Sanitation);

                        } else {
                            $("#san").val("لا");
                            $("#san").attr("data-isSan", data.subscription_File_Is_There_Sanitation);
                        }

                    } else {
                        $("input").not("#to, #sub_id, #Invoices_No").val("0");
                       
                    }
                },
                error: function (jqXhr, textStatus, errorMessage) {


                }
            });
        // }
    });

    $("#curr").on("input", function () {
        if ($(this).val() == '') {
            $(this).val(0);
        }
        var PrevConsumption = parseFloat($("#prev").val());
        var CurrentConsumption = parseFloat( $("#curr").val());
        $("#amount_consum").val(CurrentConsumption - PrevConsumption);

        var AmountOfConsumption = parseFloat($("#amount_consum").val());
        var sanitation = $("#san").attr("data-isSan");
        var NumberOfUnit = parseInt( $("#unit_no").val());
        var url = `${host}Invoices/Get_Amount_Consumption_Value?sanitation=${sanitation}&noOfUnit=${NumberOfUnit}&Amount_Consumption=${AmountOfConsumption}`

        $.ajax(url,
            {
                type: 'GET',
                dataType: 'json',
                success: function (data, status, xhr) {

                    if (data != null) {
                        $("#consum").val(data.amount_Consumption_Value);
                        $("#san_val").val(data.amount_sanitation_Value);
                        $("#Invoices_Total_Invoice").val(data.totalOfConsumpton)

                        var tax = data.totalOfConsumpton * (parseFloat($("#tax").val() / 100));
                        var fee = parseFloat($("#fee").val());
                        var Total_Bill = data.totalOfConsumpton + tax + parseFloat(fee);
                        $("#Total_Bill").val(Total_Bill.toFixed(2));

                    } else {
                        $("#consum, #amount_consum, #san_val, #Invoices_Total_Invoice, #Invoices_Total_Bill, #Total_Bill, #fee, #tax").val("0")
                    }




                },
                error: function (jqXhr, textStatus, errorMessage) {


                }
            });


    })

    $("#fee, #tax").on("input ", function () {

        if ($(this).val() == '') {
            $(this).val(0);

            var Invoices_Total_Invoice = parseFloat($("#Invoices_Total_Invoice").val());
            var tax = Invoices_Total_Invoice * (parseFloat($("#tax").val() / 100));
            var fee = parseFloat($("#fee").val())
            $("#Total_Bill").val((Invoices_Total_Invoice + tax + fee).toFixed(2));
        }

        var Invoices_Total_Invoice = parseFloat($("#Invoices_Total_Invoice").val());
        var tax = Invoices_Total_Invoice * (parseFloat($("#tax").val() / 100));
        var fee = parseFloat($("#fee").val())
        $("#Total_Bill").val((Invoices_Total_Invoice + tax + fee).toFixed(2));

    })


})
                                    









