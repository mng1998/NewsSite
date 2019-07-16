//$('#sub-management').ready(function () {
//    $.ajax({
//        url: '/admin/service/GetEntities/',
//        data: null,
//        type: 'Get',
//        contentType: 'application/json',

//        success: function (data) {
//            data.table.forEach((inner) => {
//                var html = '<li><a class="" href="/Admin/'+ inner +'"><span class="fa fa-arrow-right">&nbsp;</span>' + inner + '</a></li>';
//                html = $.parseHTML(html);
//                $("#sub-management").append(html);
//            });
//        },
//        error: function () {
//        }
//    });
//});

var app = new Vue({
    el: '#app',
    mounted() {
        console.log('mounted');
        axios.get('/admin/service/GetEntities/')
            .then(res => {
                res.data.table.forEach((inner) => {
                    var html = '<li><a class="" href="/Admin/' + inner + '"><span class="fa fa-arrow-right">&nbsp;</span>' + inner + '</a></li>';
                    html = $.parseHTML(html);
                    $("#sub-management").append(html);
                })
            })
            .catch(err => {
                console.log(err);
            })
    }
});




