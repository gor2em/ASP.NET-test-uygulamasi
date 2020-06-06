<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="testOdev4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        #main {
            margin: 30px auto;
            width: 1200px;
        }

        #left-side {
            width: 800px;
            float: left;
        }

        #right-side {
            width: 400px;
            float: left;
            background: #e8e8e8;
            text-align: center;
            padding-top: 10px;
        }

        input[type="submit"] {
            border: none;
            padding: 20px;
            text-align: center;
            cursor: pointer;
            border:1px solid #ccc;
            color:#000;
        }
        /*#00ff90*/

        .btnHover:hover {
            transition-duration: 200ms;
            border:1px solid #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="main">
            <div id="left-side">
                <asp:Button ID="btn_basla" runat="server" Text="Başlat" OnClick="btn_basla_Click" />
                <br />
                <br />
                <asp:Panel ID="Panel1" runat="server" Width="795">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Label ID="lbl_dakika" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lbl_saniye" runat="server" Text=""></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" Enabled="False">
                    </asp:Timer>

                    <asp:TextBox ID="TextBox1" runat="server" Height="150px" Width="434px" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Doğru:"></asp:Label><asp:Label ID="lbl_dogru" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="Label3" runat="server" Text="Yanlış:"></asp:Label><asp:Label ID="lbl_yanlis" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="Label1" runat="server" Text="Soru:"></asp:Label><asp:Label ID="lbl_soru" runat="server" Text=""></asp:Label><asp:Label ID="lbl_topSoru" runat="server" Text=""></asp:Label><br />


                    <br />
                    <br />
                    <asp:Button ID="btn1" runat="server" Text="A" CssClass="btnHover" OnClick="btn1_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btn2" runat="server" Text="B" CssClass="btnHover" OnClick="btn2_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btn3" runat="server" Text="C" CssClass="btnHover" OnClick="btn3_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btn4" runat="server" Text="D" CssClass="btnHover" OnClick="btn4_Click" />

                </asp:Panel>
            </div>
            <div id="right-side">
                <asp:Button ID="btn_cevap" runat="server" Text="Cevabı Göster" OnClick="btn_cevap_Click"  />
                <br /><br />
                <asp:Button ID="btn_sonuc" runat="server" Text="Sonuç" OnClick="btn_sonuc_Click" Visible="False" />
                <br />
                <asp:Label ID="lbl_sonuc" runat="server" Text="0" Visible="false"></asp:Label><br />
                <asp:Label ID="lbl_sureTOP" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lbl_cevap" runat="server" Text="" Visible="false"></asp:Label><br />

                <h1>görkem acar</h1>

            </div>
        </div>



    </form>
</body>
</html>
