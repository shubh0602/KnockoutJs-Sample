//Using revealing module pattern
MyAppNamespace_UserList = function () {
    var userList = ko.observableArray([]);
    var userDetails = ko.observable('');

    var init = function () {
        /* Here we will get all users and bind it with knockout*/
        getUserList();

        ko.applyBindings(this);//Need to apply so that binding could take place

    };
    var getUserList = function () {
        //Ajax call that will get List<User> from API
        $.ajax({
            type: "GET",
            async: false,
            url: "api/User",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done(function (data) {
            bindUserList(data);
        }).fail(function (request, error) {
            //Do some Stuff
        });
    };
    //Assign User to knockout variable which would be binding in HTML markup
    var bindUserList = function (list) {
        userList.removeAll();
        $.each(list, function (key, value) {
            userList.push(value);
        });
        $("#UserDetails").css("display", "none");
        $("#ListOfUsers").css("display", "block");
    };
    var fnUserDetails = function (value) {

        //Ajax call that will get User from API
        $.ajax({
            type: "GET",
            async: false,
            url: "api/User/" + value.Id,
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done(function (data) {
            bindUserDetails(data);
        }).fail(function (request, error) {
            //Do some Stuff
        });
    };
    //Assign User to knockout variable which would be binding in HTML markup
    var bindUserDetails = function (details) {
        $("#UserDetails").css("display", "block");
        $("#ListOfUsers").css("display", "none");

        userDetails(details);
    };
    //Assign User to knockout variable which would be binding in HTML markup
    var saveUserDetails = function (details) {


        //Ajax call that will Save User from API
        $.ajax({
            type: "POST",
            async: false,
            url: "api/User/",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(userDetails)
        }).done(function (data) {
            getUserList();
            // $("#UserDetails").css("display", "none");
            // $("#ListOfUsers").css("display", "block");
        }).fail(function (request, error) {
            //Do some Stuff.
            alert('Failed');
        });
    };
    function SamplejQuery() {
       

    };
    return {
        init: init,
        userList: userList,
        fnUserDetails: fnUserDetails,
        userDetails: userDetails,
        getUserList: getUserList,
        saveUserDetails: saveUserDetails
    }
}();

$(function () {
    MyAppNamespace_UserList.init();
});