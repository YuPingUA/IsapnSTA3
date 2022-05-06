function SaveCategory() {
    //alert('clicked');
    var url = "~/Post";
    var objectCategory = {};
    //objectCategory.CourseId = $('#txtCourseId').val();
    objectCategory.fCourseId = 2;
    objectCategory.fName = $('#txtCategoryName').val();
    objectCategory.fContent = $('#txtCategoryContent').val();


    if (objectCategory) {
        $.ajax({
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(objectCategory),
            type: "Post",
            success: function (result) {
                alert(result);
            },
            error: function (msg) {
                alert(msg);
            }
        });
    }

}