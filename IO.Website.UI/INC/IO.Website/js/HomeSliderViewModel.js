/// <reference path="jquery-1.11.0.min.js" />
/// <reference path="../../../../jondu.sisa.branding/js/jquery.bxslider.min.js" />
/// <reference path="knockout-3.1.0.js" />
var HomeSliderViewModel = function () {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { });
    var _statusID = '';
    var _self = this;
    var _siteCollectionUrl = _spPageContextInfo.webAbsoluteUrl;

    this.Pictures = ko.observableArray([]);

    function OnError(jqXHR, status, errorMessage) {
        _statusID = SP.UI.Status.addStatus('Error', errorMessage, true);
        SP.UI.Status.setStatusPriColor(_statusID, 'red');
    }

    function OnSuccess(data, status, jqXHR) {
        var result = data.GetHomeSlidesResult;
        var currentPicture;
        for (var index = 0; index < result.length; index++) {
            currentPicture = result[index]
            currentPicture.Index = ko.observable(index);
            currentPicture.ImageUrlBackgroundStyle = ko.computed(function () { return "url('" + currentPicture.ImageUrl + "')" });
            currentPicture.Class = ko.computed(function () { if (this.Index() == 0) { return 'item active' } else { return 'item'; } });
            _self.Pictures.push(currentPicture);
        }
    }

    jQuery.ajax(
        {
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',            
            type: 'GET',
            url: _spPageContextInfo.siteAbsoluteUrl + '/_vti_bin/IO.WebSite.API/SliderService.svc/Home?siteCollectionUrl=' + _siteCollectionUrl,
            success: OnSuccess,
            error: OnError
        });
}