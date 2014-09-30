/// <reference path="knockout-3.2.0.js" />
/// <reference path="knockout.validation.js" />
/// <reference path="jquery-2.1.1.min.js" />

var ProductSliderViewModel = function (sliderType) {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { });
    var _statusID = '';
    var _self = this;
    var _siteCollectionUrl = _spPageContextInfo.webAbsoluteUrl;
    var _sliderType = sliderType;

    function OnError(jqXHR, status, errorMessage) {
        _statusID = SP.UI.Status.addStatus('Error', errorMessage, true);
        SP.UI.Status.setStatusPriColor(_statusID, 'red');
    }

    function OnSuccess(data, status, jqXHR) {
        var result = data.GetProductSlidesResult;
        for (var i = 0; i < result.length; i++) {
            var container = {};
            container.Childs = ko.observableArray();
            for (var index = 0; index < 3 && i < result.length; index++) {
                var currentPicture = result[i];
                currentPicture.OpenVideo = function () {
                    SP.UI.ModalDialog.showModalDialog(
                        {
                            title: currentPicture.YoutubeVideoTitle,
                            url: currentPicture.YoutubeUrl,
                            autosize: true,
                            allowMaximize: false,
                            showClose: true
                        });
                }
                container.Childs.push(currentPicture);
                i++;
            }

            container.Index = ko.observable(i % 3);
            container.Class = ko.computed(function () { if (container.Index() == 0) { return 'item active' } else { return 'item'; } });
            container.IndicatorClass = ko.computed(function () { if (container.Index() == 0) { return 'active' } else { return ''; } });
            _self.Products.push(container);
        }


    }

    this.Products = ko.observableArray();

    jQuery.ajax(
        {
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            type: 'GET',
            url: _spPageContextInfo.webAbsoluteUrl + '/_vti_bin/IO.WebSite.API/SliderService.svc/Products/' + _sliderType + '?siteCollectionUrl=' + _siteCollectionUrl,
            success: OnSuccess,
            error: OnError
        });
}