// POST: USER/LOGIN
function userLogin() {
    var form = $("#loginForm");
    var data = form.serialize();
    form.validate();
    if (form.valid()) {
        
        $.post("/User/Login", data, function (res) {
            if (res == "success") {
                window.location.href = "/User/Index";

            }
            else {
                alert(res);
            }
            
        })
    }
    else {
        alert("form not valid");
    }
    
}

// GET: USER/CREATE FORM
function userRegister() {
    $.get("/User/Create", null, function (res) {
        $("#modalContent").html(res);
        $("#myModal").modal('show');
    })
}

// POST: USER/CREATE FORM
function saveUserRegister() {
    debugger;
    var form = $("#registerForm");
    var data = form.serialize();
    form.validate();
    if (form.valid()) {
        $.post("/User/Create", data, function (res) {

                alert(res);
                $("#myModal").modal('hide');
                window.location.href = "/User/Login";

        })
    }
    else {
        alert("form not valid");
    }
    
}

// GET: USER/USERLIST

$(function () {
    $table = $('#getUserList');
    $table.load('/User/UserList');
})

// GET: USER/EDIT
function editUser(url) {
    $.get(url, null, function (res) {
        $("#modalContent").html(res);
        $("#myModal").modal('show');
    })
}
// POST: USER/EDIT

function saveUserEdit(url) {
    debugger;
    var form = $("#editForm");
    var data = form.serialize();
    form.validate();
    if (form.valid()) {
        $.ajax({
            url: url,
            type : 'POST',
            data: data,
            complete: function (res) {
                alert(res.responseText);
                $("#myModal").modal('hide');
                  $('#getUserList').load('/User/UserList');

            }

        })
       
    }
    else {
        alert("invalid form");
    }

}

// GET: USER/DETAILS
function detailUser(url) {
    $.get(url, null, function (res) {
        $("#modalContent").html(res);
        $("#myModal").modal('show');
    })
}

// USER DELETE BY ID
function deleteUser(url) {
    if (confirm("Are you sure want to delete") == true) {
        $.post(url, null, function (res) {
            if (res) {
                $('#getUserList').load('/User/UserList');

            }

        });
    }

}




// TASK
// TASK CATEGORY
// TASK/TASKCATEGORY CREATE
$(function () {
    $div = $('#divTaskList');
    $div.load('/Task/TaskList');
})

// GET: TASK CREATE OPEN MODAL
function modalAddTask() {
    debugger;
    $.get("/Task/Create", null, function (res) {
        $("#modalContent").html(res);
        $("#myModal").modal('show');
    })
}

// POST: TASK CREATE

function saveTaskCreate() {
    debugger;
    var form = $("#createForm");
    var data = form.serialize();
    form.validate();
    
    if (form.valid()) {
        
            $.post("/Task/Create", data, function (res) {
                if (res) {
                    alert(res);
                    $("#myModal").modal('hide');
                    $div.load('/Task/TaskList');

                }
                else {
                    alert("invalid");
                }
            })
        
        
    }
    else {
        alert(" form not valid");
    }
   
}


