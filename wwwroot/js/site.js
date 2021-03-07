// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let currentCustomerId = "";
const HOME_PATH = "Home"
function getCustomerProducts(e, id) {
    e.preventDefaults;
    currentCustomerId = id;
    $(".customers-list").hide();
    $(".add-customer-product").hide();
    const path = `${HOME_PATH}/GetCustomerProducts/${id}`;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: path,
        success: function (data) {
            const customer = data["Customer"];
            const customerProductArr = data["CustomerProducts"];
            if (customerProductArr?.length > 0)
                fillCustomerProductTable(customer, customerProductArr);
            else {
                //TODO
                //no customerproducts
            }
            $(".customer-products-list").show();
        }
        ,
        error: function (returnval) {
            //TODO
                //no customerproducts
            $(".customer-products-list").show();
        }

    });
}
function backToCustomres(e) {
    e.preventDefaults;
    currentCustomerId = "";
    $(".customers-list").show();
    $(".customer-products-list").hide();
    $(".add-customer-product").hide();

}
function backToCustomreProducts() {
    $("#add-customer-product-link").show();
    $(".add-customer-product").hide();

}
function addCustomerProduct(e) {
    e.preventDefaults;
    resetForm();
    $("#add-customer-product-link").hide();
    $(".add-customer-product").show();

}
function fillCustomerProductTable(customer, customerProductArr) {
    $("#tblCustomerProducts tbody").html("");
    $(".first-name").text(customer.FirstName);
    $(".last-name").text(customer.LastName);
    $.each(customerProductArr, function (index, item) {
        let row = `<tr>
                        <td>${item.customer.FirstName} ${item.customer.LastName}</td>
                        <td>${item.product.ProductType}</td>
                        <td>${item.product.FinanceInstitue}</td>
                        <td>${item.AccountNumber}</td>
                        <td>${numberWithCommas(item.Sum)}</td>
                        <td>${item.Status}</td>
                    </tr>`;
        $("#tblCustomerProducts tbody").append(row);
    });

}

function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
function resetForm() {
    $("#products option:selected").prop("selected", false)
    $("#accountNumber").val("");
    $("#sum").val("");
    $(".error").hide();
}
function cancel() {
    backToCustomreProducts();
}

function save() {
    //TODO
    if (!isValid())
        return;
      const customerProduct = {
         "ProductID": $("#products option:selected").val()
        , "CustomerID": currentCustomerId
        , "Sum": $("#sum").val()
        , "AccountNumber": $("#accountNumber").val()

    };


    //console.log(customerProduct);

    const path = `${HOME_PATH}/PostSaveCustomerProduct`;

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: path,
        contentType: 'application/json',
        data: JSON.stringify(customerProduct),
        success: function (data) {
            console.log(data);
            const validationResult = data["ValidationResult"];
            console.log(validationResult);
            if (validationResult.length > 0)
                setServerSideValidationErrors(validationResult);
            else
                addNewCustomerProduct(data["CustomerProductNew"]);
            backToCustomreProducts();
        }
        //,
        //error: function (returnval) {
        //    //$(".message").text(returnval + " failure");
        //    //$(".message").fadeIn("slow");
        //    //$(".message").delay(2000).fadeOut(1000);
        //    //TODO
        //    //no customerproducts
        //}

    });
}
function addNewCustomerProduct(customerProduct) {
    let row = `<tr>
                    <td>${customerProduct.customer.FirstName} ${customerProduct.customer.LastName}</td>
                    <td>${customerProduct.product.ProductType}</td>
                    <td>${customerProduct.product.FinanceInstitue}</td>
                    <td>${customerProduct.AccountNumber}</td>
                    <td>${numberWithCommas(customerProduct.Sum)}</td>
                    <td>${customerProduct.Status}</td>
                </tr>`;
    $("#tblCustomerProducts tbody").append(row);
}

//Validation side client
function isValid() {
    $(".error").hide();
    let result = true;
    console.log($("#products option:selected").val())
    if ($("#products option:selected").val() == -1) {
        $("#productListError").show();
        result = false;
    }

    if ($("#accountNumber").val() == "") {
        $("#accountNumberError").text("חסר חשבון").show();
        result = false;
    }
    else if (isNaN($("#accountNumber").val()) || $("#accountNumber").val().indexOf('.') > -1 || $("#accountNumber").val().indexOf('-') > -1) {
        $("#accountNumberError").html("חשבון מכיל תווים לא חוקיים").show();
        result = false;
    }
    if ($("#sum").val() == "") {
        $("#sumError").text("חסר סכום").show();
        result = false;
    }
    else if (isNaN($("#sum").val()) || $("#sum").val().indexOf('-') > -1) {
        $("#sumError").html("סכום מכיל תווים לא חוקיים").show();
        result = false;
    }

    return result;
}
function setServerSideValidationErrors(validationResult) {
    let txtError = '';
    const errorsMsg = validationResult[0].Errors;
    $.each(errorsMsg, function (index, item) {
        txtError += `${item.ErrorMessage}\n` ;
    });
    alert(txtError);
}
