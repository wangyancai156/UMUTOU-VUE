

var app = new Vue({
    el: '#container',
    data: {
        //datalist: [{ "username": "asdasd" }, { "username": "asd123123" }],
        datalist: [],
        message: "asdasd"
    },
    created: function () {
        let that = this;
        $.ajax({
            url: '/bw/inoutbound/getspotinventory',
            type: 'get',
            dataType: 'json',
            success: function (jsonData) {
                app.datalist = jsonData;
                console.log(app.datalist);
            }
        })
    }
})