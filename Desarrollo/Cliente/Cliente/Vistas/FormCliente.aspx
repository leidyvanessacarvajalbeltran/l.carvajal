<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCliente.aspx.cs" Inherits="Cliente.Vistas.FormCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
        <ext:Panel
            runat="server"
            Layout="FitLayout"
            Width="1000"
            Height="400">
            <Items>
                <ext:FormPanel
                    ID="FormPanel1"
                    runat="server"
                    Title="Información del Estudiante"
                    BodyPadding="5"
                    ButtonAlign="Right"
                    Layout="Column">
                    <Items>
                        <ext:Panel
                            runat="server"
                            Border="false"
                            Header="false"
                            ColumnWidth=".3"
                            Layout="Form"
                            LabelAlign="Top">
                            <%-- <Defaults>
                                <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                <ext:Parameter Name="MsgTarget" Value="side" />
                            </Defaults>--%>
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Documento" AnchorHorizontal="70%" ID="txt_ESTU_ID" Hidden="true" />
                                <ext:TextField runat="server" FieldLabel="Documento" AnchorHorizontal="70%" ID="txt_doc" AllowBlank="false" />
                                <ext:TextField runat="server" FieldLabel="Primer Nombre" AnchorHorizontal="70%" ID="txt_pnomb" AllowBlank="false" />
                                <ext:TextField runat="server" FieldLabel="Segundo Nombre" AnchorHorizontal="70%" ID="txt_snomb" />
                                <ext:TextField runat="server" FieldLabel="Primer Apellido" AnchorHorizontal="70%" ID="txt_papell" AllowBlank="false" />
                                <ext:TextField runat="server" FieldLabel="Segundo Apellido" AnchorHorizontal="70%" ID="txt_sapell" />
                                <ext:TextField runat="server" FieldLabel="Correo" AnchorHorizontal="70%" ID="txt_corre" AllowBlank="false" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Border="false" Layout="FitLayout" ColumnWidth=".7" LabelAlign="Top">
                            <Items>
                                <ext:GridPanel
                                    runat="server"
                                    Title="Registrados">
                                    <Store>
                                        <ext:Store
                                            ID="S_datos"
                                            runat="server">
                                            <Model>
                                                <ext:Model runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="ESTU_IDENTIFICACION" />
                                                        <ext:ModelField Name="ESTU_PNOMBRE" />
                                                        <ext:ModelField Name="ESTU_SNOMBRE" />
                                                        <ext:ModelField Name="ESTU_PAPELLIDO" />
                                                        <ext:ModelField Name="ESTU_SAPELLIDO" />
                                                        <ext:ModelField Name="ESTU_EMAIL" />
                                                        <ext:ModelField Name="ESTUDIANTE" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="Documento" Flex="1" DataIndex="ESTU_IDENTIFICACION" />
                                            <ext:Column runat="server" Text="Nombre" Flex="1" DataIndex="ESTUDIANTE" />
                                            <ext:Column runat="server" Text="Email" Flex="1" DataIndex="ESTU_EMAIL" />
                                        </Columns>
                                    </ColumnModel>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button
                    ID="Button1"
                    runat="server"
                    Text="Save"
                    Disabled="false"
                    FormBind="true">
                    <DirectEvents>
                        <Click OnEvent="registrar">
                            <ExtraParams>                                
                                <ext:Parameter Name="datosPersona" Value="#{FormPanel1}.getForm().getValues(false,false,false,true)" Mode="Raw" />
                            </ExtraParams>
                            <EventMask Msg="Guardando.." ShowMask="true" Target="CustomTarget" CustomTarget="FormPanel1" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:Panel>
    </form>
</body>
</html>
