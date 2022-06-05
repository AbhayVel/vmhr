function pageSubmit() {
    getAjaxCall();
}

function pageChange(currentPage) {
    event.preventDefault();


    document.getElementById("currentPage").value = currentPage;
    pageSubmit();
    return false;
}


function isDelete() {
    if (confirm("do you want to delete.")) {

    } else {
        event.preventDefault();
        return false;
    }
}


function sort(columnName, orderBy) {
    event.preventDefault();


    document.getElementById("columnName").value = columnName;
    if ("asc" == orderBy) {
        document.getElementById("orderBy").value = "desc";
    } else {
        document.getElementById("orderBy").value = "asc";
    }


    pageSubmit();
    return false;
}


   function getAjaxCall(){
       let form= document.querySelector("form");
       let formData= new FormData(form);

       var obj={};

       for(var key in formData.keys()){
           obj[key]=formData.get(key);
       }

       $.ajax({
           url: "/TimeSheet/Index",
             data: $('form').serialize(),
             datatype: 'json',
             method: "Post",
             type: "Post",
           success: function(res){
              document.querySelector("#ajaxHtML").innerHTML=res;
           },
           error: function(err){
               debugger
           }
       })
   }
