@ModelType CasualBoutique.State
@Code
    ViewData("Title") = "Delete state"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>State</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.Label("State name", htmlAttributes:=New With {.class = "control-label col-md-2"})
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StateName)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            @Html.ActionLink("Back", "Index", vbNull, New With {.class = "btn btn-primary"})
            &nbsp;
            <input type="submit" value="Delete" class="btn btn-primary" />
        </div>
    End Using
</div>
