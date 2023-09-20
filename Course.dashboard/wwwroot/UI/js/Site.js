function AddToCart(id, name, url) {
    $(document).ready(function () {
        $.ajax({
            url: `/UI/Cart/Add?Id=${id}&UName=${name}&returnUrl=${url}`,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data)
            }
        })

    })
}