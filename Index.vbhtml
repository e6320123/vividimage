@Code
    ViewBag.Title = "訂單系統 - 登入"
    Dim Result = ViewBag.Result
End Code

<h2>@ViewBag.Title</h2>

<form method="post" action="Index">
    
    <div>
        <span style="color:red">@ViewBag.Msg</span>
    </div>
    <div class="form-group">
        <label for="inputacc">帳號/Email</label>
        <div>
            <input type="text" id="inputacc" name="Sys_Acc" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label for="inputpwd">密碼</label>
        <div>
            <input type="password" id="inputpwd" name="Sys_Pwd" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label for="inputvalid">驗證碼</label>
        <div>
            <input autocomplete="off" type="text" id="inputvalid" name="Code" class="form-control" />
            <img id="Code" src="GetValidateCode/" />
        </div>
    </div>
    <input type="submit" class="btn btn-default" value="送出" />
</form>

