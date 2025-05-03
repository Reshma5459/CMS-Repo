<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="HOME.aspx.cs" Inherits="WebApplication2.HOME" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Css/Controll.css" rel="stylesheet" type="text/css" />
    <link href="Css/Mainmaster.css" rel="stylesheet" type="text/css" />
    <link href="Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .main
        {
            padding:20px;
        }
        .main__heading
        {
          text-align :center;
          margin-bottom:20px;
         background-color:antiquewhite;
        }
        .cards__inner
        {
            display:flex;
            flex-warp:warp;
            gap:20px;
            justify-content:center;
        }
        .cards__card
        {
            flex:1;
            min-width:300px;
            max-width:300px;
            background-color:#f8f9fa;
            padding:20px;
            border:1px solid #dee2e6;
            border-radius:8px;
            box-shadow:0 4px 6px rgba(0,0,0,0.1);
            transition: transform 0.3s ease,box-shadow 0.3s ease;
        }
        .cards__card:hover
        {
            transform: translateY(-10px);
            box-shadow:0 6px 10px rgba(0,0,0,0.15);
        }
        .card__heading {
            font-size: 1.5rem;
            margin-bottom:10px
        }
        .overlay {
            background: rgba(0,0,0,0.5);
            position:absolute;
            top:0;
            left:0;
            right:0;
            bottom:0;
            display:none;
        }
        
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <main class="main">
       <h2 class="main__heading"> We Are Providing and organizing</h2>
       <div class="main__cards cards">
           <div class="cards__inner">
               <div class="cards__card card">
                   <h3 class="card__heading"> Memberships </h3>
                   <p>
                       memberships like Basic,Premium,and other memberships etc and fees according to membership
                   </p>
               </div>
               <div class="cards__card card">
                   <h3 class="card__heading"> Facilities</h3>
                   <p>
                       we provide facilities to the customer based on the membership they have chosen
                   </p>
               </div>
               <div class="cards__card card">
                   <h3 class="card__heading">Events</h3>
                   <p>
                       we are organizing events for the cutomer like cultural events,social events,seminars,conference and meetingd
                   </p>
               </div>
           </div>
       </div>
   </main>
 </asp:Content>
