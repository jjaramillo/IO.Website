/// <reference path="knockout-3.2.0.js" />
/// <reference path="knockout.validation.js" />
/// <reference path="jquery-2.1.1.min.js" />

var WorkWithUsRequestViewModel = function () {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { });
    var _statusID = '';
    var _self = this;
    var _siteCollectionUrl = _spPageContextInfo.webAbsoluteUrl;
    var _validationResult;


    function OnError(jqXHR, status, errorMessage) {
        _statusID = SP.UI.Status.addStatus('Error', errorMessage, true);
        SP.UI.Status.setStatusPriColor(_statusID, 'red');
    }

    function OnSuccess(data, status, jqXHR) {

    }

    this.firstName = ko.observable('').extend({ required: true });
    this.lastName = ko.observable('').extend({ required: true });
    this.email = ko.observable('').extend({ required: true });
    this.file = ko.observable('');
    this.fileBinary = ko.observable('');
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
                    url: _siteCollectionUrl + '/layouts/_vti_bin/IO.Website.API/WorkWithUsRequestService.svc/Add',
                    type: 'PUT',
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    data: ko.toJSON({
                        firstName: _self.firstName(),
                        lastName: _self.lastName(),
                        email: _self.email(),
                        fileData: _self.fileBinary(),
                        fileName: _self.file().name,
                        siteCollectionUrl: _siteCollectionUrl
                    }),
                    success: OnSuccess,
                    error: OnError
                }
            );
        }
        else {
            _statusID = SP.UI.Status.addStatus('Advertencia', 'No se puede enviar su solicitud de contacto. Por favor verifique el formulario e int&eacute;ntelo de nuevo.', true);
            SP.UI.Status.setStatusPriColor(_statusID, 'yellow');
            _validationResult.showAllMessages();
        }

    }

}