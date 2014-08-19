/// <reference path="knockout-3.2.0.js" />
/// <reference path="knockout.validation.js" />
/// <reference path="jquery-2.1.1.min.js" />

var DemoRequestViewModel = function () {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { });
    var _statusID = '';
    var _self = this;
    var _siteCollectionUrl = _spPageContextInfo.siteAbsoluteUrl;
    var _validationResult;

    function OnError(jqXHR, status, errorMessage) {
        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK);
        _statusID = SP.UI.Status.addStatus('Error', errorMessage, true);
        SP.UI.Status.setStatusPriColor(_statusID, 'red');
    }

    function OnSuccess(data, status, jqXHR) {
        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK);
        _self.formvisible(false);
        _self.messagevisible(true);
    }

    this.firstName = ko.observable('').extend({ required: true });
    this.lastName = ko.observable('').extend({ required: true });
    this.company = ko.observable('').extend({ required: true });
    this.email = ko.observable('').extend({ required: true });
    this.phone = ko.observable('').extend({ required: true });
    this.mobile = ko.observable('').extend({ required: true });
    this.city = ko.observable('').extend({ required: true });
    this.formvisible = ko.observable(true);
    this.messagevisible = ko.observable(false);

    ko.validatedObservable(_self);
    _validationResult = ko.validation.group(_self, { deep: true });

    this.Save = function () {
        if (_self.isValid() === true) {
            SP.UI.ModalDialog.showWaitScreenWithNoClose(SP.Res.dialogLoading15);
            $.ajax(
                {
                    cache: false,
                    url: _siteCollectionUrl + '/layouts/_vti_bin/IO.Website.API/DemoRequest.svc/Add',
                    type: 'PUT',
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    data: ko.toJSON({
                        firstName: _self.firstName(),
                        lastName: _self.lastName(),
                        company: _self.company(),
                        email: _self.email(),
                        phone: _self.phone(),
                        mobile: _self.mobile(),
                        city: _self.city(),
                        siteCollectionUrl: _siteCollectionUrl
                    }),
                    success: OnSuccess,
                    error: OnError
                }
            );
        }
        else {
            _statusID = SP.UI.Status.addStatus('Advertencia', 'No se puede enviar su solicitud de demostraci&oacute;n. Por favor verifique el formulario e int&eacute;ntelo de nuevo.', true);
            SP.UI.Status.setStatusPriColor(_statusID, 'yellow');
            _validationResult.showAllMessages();
        }
    }
}