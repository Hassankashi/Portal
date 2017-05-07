<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat Page</title>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<script src="js/jquery-2.0.3.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
<link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/smoothness/jquery-ui.css" rel="stylesheet" />

<script>
    $(function () {
        $("#tabs").tabs();
    });
</script>

   <script language="javascript" type="text/javascript">
       window.setInterval(getChat, 500);

       function getChat() {
            $.getJSON("api/chat/2",
            function (data) {
         //  alert(data);
         //   $('#div1').empty(); // Clear the table body.
         
                // Loop through the list of products.
                $.each(data, function (key, val) {
                    
                        $('#div1').append(data.toString()+'<br>');
                    
                });
            });
        }

        function InsertData() {
        
          var mystr=$("#txtValue1").val(); 
          //Emp.FirstName=$("#txtValue1").val();
         // Emp.LastName='kashi';
            $.ajax({
                url: "<%=Page.ResolveUrl("~/api/Chat/Post")%>",
                type: "POST",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(mystr),
                dataType: "json"
                 });
           
        }

     

       function mykey(event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if(keycode == '13') {
           InsertData() ;
           $("#txtValue1").val("");
           // location.reload();
            }
        };

       
   $(document).keypress(
                function(event){
                 if (event.which == '13') {
                    event.preventDefault();
                  }


            });
     
    

    </script>
</head>
<body>
    <form id="form1" runat="server">


    <br />
    <br />
    
   <%-- <input type="button" value="send"  onclick="InsertData()" />--%>
  
<div id="tabs">
<ul>
<li><a href="#tabs-1">Nunc tincidunt</a></li>
<li><a href="#tabs-2">Proin dolor</a></li>
<li><a href="#tabs-3">Aenean lacinia</a></li>
</ul>
<div id="tabs-1">
<div id="div1"></div>
<input type="text" onkeypress="mykey(event)"  id="txtValue1"/>
<p>Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.</p>
 
</div>
<div id="tabs-2">
<p>Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.</p>
<input type="text" onkeypress="mykey(event)"  id="fdftxtValue1"/>
    <div id="dfddiv1">
</div>
<div id="tabs-3">
<p>Mauris eleifend est et turpis. Duis id erat. Suspendisse potenti. Aliquam vulputate, pede vel vehicula accumsan, mi neque rutrum erat, eu congue orci lorem eget lorem. Vestibulum non ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce sodales. Quisque eu urna vel enim commodo pellentesque. Praesent eu risus hendrerit ligula tempus pretium. Curabitur lorem enim, pretium nec, feugiat nec, luctus a, lacus.</p>
<p>Duis cursus. Maecenas ligula eros, blandit nec, pharetra at, semper at, magna. Nullam ac lacus. Nulla facilisi. Praesent viverra justo vitae neque. Praesent blandit adipiscing velit. Suspendisse potenti. Donec mattis, pede vel pharetra blandit, magna ligula faucibus eros, id euismod lacus dolor eget odio. Nam scelerisque. Donec non libero sed nulla mattis commodo. Ut sagittis. Donec nisi lectus, feugiat porttitor, tempor ac, tempor vitae, pede. Aenean vehicula velit eu tellus interdum rutrum. Maecenas commodo. Pellentesque nec elit. Fusce in lacus. Vivamus a libero vitae lectus hendrerit hendrerit.</p>
</div>
</div>
    </form>
</body>
</html>
