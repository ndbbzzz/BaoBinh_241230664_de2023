$(function () {
    $(document).on('click', 'a.loai', function (e) {
        var id = $(this).data('id');
        if (!$("#dsHang").length) return;
        e.preventDefault();
        $('.menu li').removeClass('active');
        $(this).parent().addClass('active');
        $.get('/Home/LocTheoLoai', { maLoai: id }, function (html) {
            $("#dsHang").html(html);
        });
    });
});