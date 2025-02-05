﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImahe.aspx.cs" Inherits="ShortCourseReg.AddImahe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     
   <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=Show_Image.ClientID%>").click();
             }
        }
   </script>

    
    <style type="text/css">
        .auto-style1 {
            width: 342px;
        }
        .auto-style3 {
            width: 35px;
        }
        .auto-style4 {
            width: 105px;
        }
        .auto-style5 {
            width: 85px;
        }
    </style>

    
    </head>
<body>
    <form id="form1" runat="server">
        <div>    
        <asp:Button ID="Show_Image" runat="server" OnClick="Show_Image_Click" Text="Show image" CausesValidation="False" Style=" position: absolute; top:-1000000px; left:-10000px;   "/>
            <asp:TextBox ID="image_vale" runat="server" Visible="True" Style=" position: absolute; top:-1000000px; left:-10000px;"></asp:TextBox>
            <table>
                <tr>
                    <td style="vertical-align:top;" rowspan="2">
                        <table>
                            <tr>
                                <td>
                                   Name:
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Description" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Name" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="Name" runat="server" Width="235px"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td>
                                   Description:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Description" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="Description" runat="server" Height="115px" Width="235px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td>
                                   Category:
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Category" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="Category" runat="server" Width="235px"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td>
                                   Creator:
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Creator" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="Creator" runat="server" Width="235px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Save" runat="server" Text="Save" Width="326px" OnClick="Save_Click" Height="44px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Edit" runat="server" Text="Edit" Width="326px"  Height="44px" OnClick="Edit_Click" CausesValidation="False"/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="View" runat="server" Text="View" Width="326px"  Height="44px" OnClick="View_Click" ValidationGroup="1" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Delete" runat="server" Text="Delete" Width="326px"  Height="44px" OnClick="Delete_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align:top;" class="auto-style1">
                    <asp:Image ID="Image1" runat="server" Height="263px" Width="350px" />  
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server"  OnChange="UploadFile(this)" Width="327px"/>
                &nbsp;<asp:Label ID="saved" runat="server"></asp:Label>
                        <table>
                            <tr>
                                <td class="auto-style4">
                                    Image: 
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="image_uplod" runat="server" Width="189px" BackColor="Red"></asp:TextBox>
                                </td>
                                <td class="auto-style3">

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="image_uplod" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    Project File: 
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="ProjectFile_Uplod" runat="server" Width="189px" BackColor="Red"></asp:TextBox>
                                </td>
                                <td class="auto-style3">

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ProjectFile_Uplod" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    Database File: 
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="DatabaseFile_Uplode" runat="server" Width="189px" BackColor="Red"></asp:TextBox>
                                </td>
                                <td class="auto-style3">

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DatabaseFile_Uplode" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                    
        </div>
    </form>
</body>
</html>
