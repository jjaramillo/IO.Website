/// <reference path="knockout-3.2.0.js" />
/// <reference path="knockout.validation.js" />
/// <reference path="jquery-2.1.1.min.js" />

var ProductSliderViewModel = function () {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { });
    var _statusID = '';
    var _self = this;
    var _siteCollectionUrl = _spPageContextInfo.webAbsoluteUrl;

    function OnError(jqXHR, status, errorMessage) {
        _statusID = SP.UI.Status.addStatus('Error', errorMessage, true);
        SP.UI.Status.setStatusPriColor(_statusID, 'red');
    }

    function OnSuccess(data, status, jqXHR) {
        var result = data.GetProductSlidesResult;
        for (var i = 0; i < result.length; i++) {
            result[i].OpenVideo = function () {
                SP.UI.ModalDialog.showModalDialog(
					{
					    title: this.YoutubeVideoTitle,
					    url: '_layouts/15/IO.WebSite/ViewVideo.aspx?videoUrl=' + this.YoutubeUrl,
					    autosize: true,
					    allowMaximize: false,
					    showClose: true
					}
				);
            }
            _self.Products.push(result[i]);
        }
    }

    this.Products = ko.observableArray();

    jQuery.ajax(
        {
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            type: 'GET',
            url: _spPageContextInfo.siteAbsoluteUrl + '/_vti_bin/IO.WebSite.API/SliderService.svc/Products?siteCollectionUrl=' + _siteCollectionUrl,
            success: OnSuccess,
            error: OnError
        });
}