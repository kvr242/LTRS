 <%@ Page Title="" Language="C#" MasterPageFile="~/LTRSMaster.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="LTRS.ViewReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPContent" runat="server">
    <div>
        <table width="100%">
            <tr>

                <td align="center" valign="middle" style="padding-top: 20px">
                    <label runat="server" id="lblmessage" style="font-size: 40px; font-weight: bold"></label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%">
            <tr>

                <td align="center" valign="middle" style="padding-top: 20px">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="USER_ID" DataSourceID="SqlDataSource1" Visible="False">
                        <Columns>
                            <asp:BoundField DataField="DATE_STAMP" HeaderText="DATE STAMP" SortExpression="DATE_STAMP" DataFormatString="{0:MM/dd/yyyy HH:mm:ss:fff}" ReadOnly="true" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="USER_STATUS" HeaderText="USER STATUS" SortExpression="USER_STATUS" ReadOnly="true" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="USER_ID" HeaderText="USER ID" InsertVisible="False" ReadOnly="True" SortExpression="USER_ID" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" SortExpression="PASSWORD" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="DBA_PASSWORD" HeaderText="DBA PASSWORD" SortExpression="DBA_PASSWORD" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="FIRST_NAME" HeaderText="FIRST NAME" SortExpression="FIRST_NAME" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="LAST_NAME" HeaderText="LAST NAME" SortExpression="LAST_NAME" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="USER_NAME" HeaderText="USER NAME" SortExpression="USER_NAME" HeaderStyle-Width="50px"/>

                            <asp:BoundField DataField="PHONE_NUMBER" HeaderText="PHONE NUMBER" SortExpression="PHONE_NUMBER" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="RECOVERY_EMAIL" HeaderText="RECOVERY EMAIL" SortExpression="RECOVERY_EMAIL" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS" SortExpression="ADDRESS" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="STATE" HeaderText="STATE" SortExpression="STATE" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="ZIPCODE" HeaderText="ZIPCODE" SortExpression="ZIPCODE" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="SECURITY_QUE" HeaderText="SECURITY QUE" SortExpression="SECURITY_QUE" HeaderStyle-Width="50px"/>
                            <asp:BoundField DataField="SECURITY_ANSWER" HeaderText="SECURITY ANSWER" SortExpression="SECURITY_ANSWER" HeaderStyle-Width="50px"/>

                            <asp:BoundField DataField="USER_TYPE" HeaderText="USER TYPE" SortExpression="USER_TYPE" HeaderStyle-Width="50px"/>

                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LTRSConnectionString %>" SelectCommand="SELECT * FROM [USER_MASTER]"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>

                <td align="center" valign="middle" style="padding-top: 20px">
                    <asp:Button runat="server" ID="Button1" Text="Home" CssClass="thead-default" OnClick="btnhome_Click" CausesValidation="false" UseSubmitBehavior="false"></asp:Button>&nbsp;
                        <asp:Button runat="server" ID="Button2" Text="Next" CssClass="thead-default" OnClick="btnnext_Click" CausesValidation="false" UseSubmitBehavior="false"></asp:Button>&nbsp;
                         <asp:Button runat="server" ID="Button3" Text="Back" CssClass="thead-default" OnClick="btn_back_Click" CausesValidation="false" UseSubmitBehavior="false"></asp:Button>&nbsp;
                            <asp:Button runat="server" ID="btnexit" Text="Exit" CssClass="thead-default" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnexit_Click" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>
