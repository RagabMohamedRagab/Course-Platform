function AddToCart(id, name, url,type) {
    $(document).ready(function () {
        $.ajax({
            url: `/UI/Cart/Add?Id=${id}&UName=${name}&returnUrl=${url}&type=${type}`,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data)
            }
        })

    })
}