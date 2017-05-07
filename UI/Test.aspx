<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat Page</title>
   
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
<link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/smoothness/jquery-ui.css" rel="stylesheet" />

     <link href="css/examples.css" rel="stylesheet" />
     <link href="css/kendo.common.min.css" rel="stylesheet" />
     <link href="css/kendo.default.min.css" rel="stylesheet" />

     <script src="js/jquery.min.js"></script>
     <script src="js/kendo.web.min.js"></script>
     <script src="js/console.js"></script>
   <script language="javascript" type="text/javascript">
       window.setInterval(getChat, 500);

       function getChat() {
            $.getJSON("api/mahsa/2",
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
   
     
    <div id="example" class="k-content">
    
       <div class="configuration">
                <span class="configHead">API Functions</span>
                <ul class="options">
                    <li>
                        <input type="text" value="0" id="tabIndex" class="k-textbox"/> <button class="selectTab k-button">Select</button>
                    </li>
                    <li>
                        <button class="toggleTab k-button">Enable/Disable Selected</button>
                    </li>
                    <li>
                        <button class="removeItem k-button">Remove Selected</button>
                    </li>
                    <li>
                        <input type="text" value="Item" id="appendText" class="k-textbox"/> <button class="appendItem k-button">Append</button>
                    </li>
                    <li>
                        <input type="text" value="Item" id="beforeText" class="k-textbox"/> <button class="beforeItem k-button">Insert Before</button>
                    </li>
                    <li>
                        <input type="text" value="Item" id="afterText" class="k-textbox"/> <button class="afterItem k-button">Insert After</button>
                    </li>
                </ul>
            </div>
       <div style="width: 500px;">
                <div id="tabstrip">
                    <ul>
                        <li class="k-state-active">
                            Baseball
                        </li>
                        <li>
                            Golf
                        </li>
                        <li>
                            Swimming
                        </li>
                        <li>
                            Snowboarding
                        </li>
                    </ul>
                    <div>
                        <p>Baseball is a bat-and-ball sport played between two teams of nine players each. The aim is to score runs by hitting a thrown ball with a bat and touching a series of four bases arranged at the corners of a ninety-foot diamond. Players on the batting team take turns hitting against the pitcher of the fielding team, which tries to stop them from scoring runs by getting hitters out in any of several ways. A player on the batting team can stop at any of the bases and later advance via a teammate's hit or other means. The teams switch between batting and fielding whenever the fielding team records three outs. One turn at bat for each team constitutes an inning and nine innings make up a professional game. The team with the most runs at the end of the game wins.</p>
                    </div>
                    <div>
                        <p>Golf is a precision club and ball sport, in which competing players (or golfers) use many types of clubs to hit balls into a series of holes on a golf course using the fewest number of strokes. It is one of the few ball games that does not require a standardized playing area. Instead, the game is played on golf courses, each of which features a unique design, although courses typically consist of either nine or 18 holes. Golf is defined, in the rules of golf, as playing a ball with a club from the teeing ground into the hole by a stroke or successive strokes in accordance with the Rules.</p>
                    </div>
                    <div>
                        <p>Swimming has been recorded since prehistoric times; the earliest recording of swimming dates back to Stone Age paintings from around 7,000 years ago. Written references date from 2000 BC. Some of the earliest references to swimming include the Gilgamesh, the Iliad, the Odyssey, the Bible, Beowulf, and other sagas. In 1578, Nikolaus Wynmann, a German professor of languages, wrote the first swimming book, The Swimmer or A Dialogue on the Art of Swimming. Competitive swimming in Europe started around 1800, mostly using breaststroke.</p>
                    </div>
                    <div>
                        <p>Snowboarding is a sport that involves descending a slope that is covered with snow on a snowboard attached to a rider's feet using a special boot set onto a mounted binding. The development of snowboarding was inspired by skateboarding, sledding, surfing and skiing. It was developed in the U.S.A. in the 1960s to 1970s and became a Winter Olympic Sport in 1998.</p>
                    </div>
                </div>
    </div>
     <script>
         $(document).ready(function () {
             var getItem = function (target) {
                 var itemIndex = target[0].value;

                 return tabStrip.tabGroup.children("li").eq(itemIndex);
             },
                        select = function (e) {
                            if (e.type != "keypress" || kendo.keys.ENTER == e.keyCode)
                                tabStrip.select(getItem($("#tabIndex")));
                        },
                        append = function (e) {
                            if (e.type != "keypress" || kendo.keys.ENTER == e.keyCode)
                                tabStrip.append({
                                    data: "123",
                                    text: "gjh",
                                    content: "gjhhv",

                                });
                        },
                        before = function (e) {
                            if (e.type != "keypress" || kendo.keys.ENTER == e.keyCode)
                                tabStrip.insertBefore({
                                    text: $("#beforeText").val(),
                                    content: "<br>"
                                }, tabStrip.select());
                        },
                        after = function (e) {
                            if (e.type != "keypress" || kendo.keys.ENTER == e.keyCode)
                                tabStrip.insertAfter({
                                    text: $("#afterText").val(),
                                    content: "<br>"
                                }, tabStrip.select());
                        };
                           function onContentLoad(e) {
                    kendoConsole.log("Content loaded in <b>" + $(e.item).find("> .k-link").text() + "</b> and starts with <b>" + $(e.contentElement).text().substr(0, 20) + "...</b>");
                    kendoConsole.log("Content loaded in <b>" + $(e.item).find() + "</b> and starts with <b>" + $(e.contentElement).text().substr(0, 20) + "...</b>");
             
                }

                   function onActivate(e) {
                    kendoConsole.log("Activated: " + $(e.item).find("> .k-link").text());
                    kendoConsole.log("Content loaded in <b>" + $(e.item).data() + "</b> and starts with <b>" + $(e.contentElement).text().substr(0, 20) + "...</b>");

                }

             $(".toggleTab").click(function (e) {
                 var tab = tabStrip.select();

                 tabStrip.enable(tab, tab.hasClass("k-state-disabled"));
             });

             $(".removeItem").click(function (e) {
                 var tab = tabStrip.select(),
                            otherTab = tab.next();
                 otherTab = otherTab.length ? otherTab : tab.prev();

                 tabStrip.remove(tab);
                 tabStrip.select(otherTab);
             });

             $(".selectTab").click(select);
             $("#tabIndex").keypress(select);

             $(".appendItem").click(append);
             $("#appendText").keypress(append);

             $(".beforeItem").click(before);
             $("#beforeText").keypress(before);

             $(".afterItem").click(after);
             $("#afterText").keypress(after);
         });

         var tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");
            </script>
            <style scoped>
                .configuration .k-textbox {
                    width: 40px;
                }
            </style>
    
    </div>

    
</body>
</html>
