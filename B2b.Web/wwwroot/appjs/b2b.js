var b2b = b2b || {}
b2b.baseurl = null;
b2b.dropdown = function ($obj) {
    var data = $obj.data();
    if (!!data) {
        $.ajax({
            type: 'GET',
            url: b2b.baseurl + data.url,
            //data: JSON.stringify(obj),
            success: function (resut) {
                debugger;
                $obj.empty();
                if (!!data.option) {
                    $obj.append($('<option>').text('All ' + data.option));
                }
                $.each(resut, function (k, v) {
                    $obj.append($('<option>', { value: k }).text(v));
                });
            },
            error: function (jqXHR) { debugger },
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
    }
}
$(function () {
    b2b.baseurl = "https://localhost:44340/";
    b2b.dropdown($('#Region'));
    b2b.dropdown($('#Category'));
    b2b.dropdown($('#Brand'));
    b2b.documentclick();
})

b2b.documentclick = function () {
    $(document).on('change', 'select#Brand', function () {
        debugger;
        var $obj = $('#categoty')
        $.ajax({
            type: 'GET',
            url: b2b.baseurl + 'api/dropdown/product?cascade='+ $(this).val(),
            success: function (resut) {
                $obj.empty();
                //if (!!data.option) {
                    $obj.append($('<option>').text('All Product'));
                //}
                $.each(resut, function (k, v) {
                    $obj.append($('<option>', { value: v.key }).text(v.value));
                });
            },
            error: function (jqXHR) { debugger },
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
    });
}