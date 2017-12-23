<%@ Page Title="Flexi-FizzBuzzBazz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FlexiFizzBuzzBazz._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron kc-special">
        <h1>Flexi-FizzBuzzBazz</h1>
        <p class="lead">
            Flexi-FizzBuzzBazz generates a list of items representing the consecutive sequence of
            integers from start to end.  When the integer is a multiple of Fizz, the string
            "Fizz" is added instead. Likewise, for multiples of Buzz, "Buzz" is added. For
            multiples of both Fizz and Buzz, "FizzBuzz" is added.
        </p>
        <p>
            If the optional "Bazz" value is given, then "FizzBuzz" becomes "FizzBuzzBazz"
            for items that meet the optional condition.
        </p>
    </div>

    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="form-horizontal">
                <h4>Let's play!</h4>
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Fizz" CssClass="col-md-2 control-label">Fizz</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Fizz" TextMode="SingleLine" CssClass="form-control" MaxLength="8" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Fizz" Display="Dynamic"
                            CssClass="text-danger" ErrorMessage="The Fizz field is required." />
                        <asp:CompareValidator runat="server" ControlToValidate="Fizz" Type="Integer" Display="Dynamic"
                            CssClass="text-danger" Operator="DataTypeCheck" ErrorMessage="Fizz must be an integer!" />
                        <asp:CompareValidator runat="server" ControlToValidate="Fizz" Type="Integer" Display="Dynamic"
                            CssClass="text-danger" Operator="NotEqual" ErrorMessage="Fizz cannot be 0!" ValueToCompare="0" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Buzz" CssClass="col-md-2 control-label">Buzz</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Buzz" TextMode="SingleLine" CssClass="form-control" MaxLength="8" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Buzz" Display="Dynamic"
                            CssClass="text-danger" ErrorMessage="The Buzz field is required." />
                        <asp:CompareValidator runat="server" ControlToValidate="Buzz" Type="Integer" Display="Dynamic"
                            CssClass="text-danger" Operator="DataTypeCheck" ErrorMessage="Buzz must be an integer!" />
                        <asp:CompareValidator runat="server" ControlToValidate="Buzz" Type="Integer" Display="Dynamic"
                            CssClass="text-danger" Operator="NotEqual" ErrorMessage="Buzz cannot be 0!" ValueToCompare="0" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Start" CssClass="col-md-2 control-label">Start</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Start" TextMode="SingleLine" CssClass="form-control" MaxLength="8" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Start" Display="Dynamic"
                            CssClass="text-danger" ErrorMessage="The Start field is required." />
                        <asp:CompareValidator runat="server" ControlToValidate="Start" Type="Integer" Display="Dynamic"
                            CssClass="text-danger" Operator="DataTypeCheck" ErrorMessage="Start must be an integer!" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="End" CssClass="col-md-2 control-label">End</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="End" TextMode="SingleLine" CssClass="form-control" MaxLength="8" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="End" Display="Dynamic"
                            CssClass="text-danger" ErrorMessage="The End field is required." />
                        <asp:CompareValidator runat="server" ControlToValidate="End" Type="Integer" Display="Dynamic"
                            CssClass="text-danger" Operator="DataTypeCheck" ErrorMessage="End must be an integer!" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Bazz" CssClass="col-md-2 control-label">Bazz</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="PredicateSelect" runat="server" CssClass="form-control" Width="130px">
                            <asp:ListItem Text="(Optional)" Value="0" />
                            <asp:ListItem Text="Less than" Value="1" />
                            <asp:ListItem Text="Equal to" Value="2" />
                            <asp:ListItem Text="Greater than" Value="3" />
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="Bazz" TextMode="SingleLine" CssClass="form-control" MaxLength="8" />
                        <asp:Label AssociatedControlID="Bazz" runat="server" Text="(optional)" CssClass="control-label"></asp:Label>
                        <asp:CompareValidator runat="server" ControlToValidate="Bazz" Type="Integer" Display="Dynamic"
                            CssClass="text-danger" Operator="DataTypeCheck" ErrorMessage="Bazz must be an integer!" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" ID="Run" Text="Run" OnClick="Run_Click" CssClass="btn btn-primary" />
                    </div>
                </div>

                <hr />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Result" CssClass="col-md-2 control-label">Result</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Result" TextMode="MultiLine" CssClass="form-control" ReadOnly="False" Width="250px" Height="200px" />
                    </div>
                </div>

            </div>
        </div>
        <div class="col-md-3"></div>

    </div>

    <script type="text/javascript">
        // When the "Run" button is pressed:
        //  (1) Change "Result" textbox
        //  (2) Disable the "Run" button
        //  (3) Set the wait cursor
        function OnRunButtonPressed() {
            document.getElementById("<%=Result.ClientID %>").textContent = "Processing...";
            document.getElementById("<%=Run.ClientID %>").disabled = true;
            document.body.style.cursor = 'wait';
        }
        window.onbeforeunload = OnRunButtonPressed;
    </script>

</asp:Content>
