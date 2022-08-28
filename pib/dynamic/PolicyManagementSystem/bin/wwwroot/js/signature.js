(function (ns) {
    //"use strict";

    ns.SignatureControl = function (options) {
        var containerId = options && options.canvasId || "canvasContainer",
            callback = options && options.callback || {},
            label = options && options.label || "Signature",
            cWidth = options && options.width || "300px",
            cHeight = options && options.height || "300px",
            btnClearId,
            btnAcceptId,
            canvas,
            ctx;

        function initCotnrol() {
            createControlElements();
            wireButtonEvents();
            canvas = document.getElementById("signatureCanvas");
            canvas.addEventListener("mousedown", pointerDown, false);
            canvas.addEventListener("mouseup", pointerUp, false);
            ctx = canvas.getContext("2d");            
        }

        function createControlElements() {            
            var signatureArea = document.createElement("div"),
                labelDiv = document.createElement("div"),
                canvasDiv = document.createElement("div"),
                canvasElement = document.createElement("canvas"),
                buttonsContainer = document.createElement("div"),
                buttonClear = document.createElement("span"),
                buttonAccept = document.createElement("button");

            labelDiv.className = "signatureLabel";
            labelDiv.textContent = label;

            canvasElement.id = "signatureCanvas";
            canvasElement.clientWidth = "300px";
            canvasElement.clientHeight = "300px";
            canvasElement.style.border = "solid 2px black";

            buttonClear.id = "btnClear";
            buttonClear.textContent = "Clear";

            buttonAccept.id = "btnAccept";
            buttonAccept.textContent = "Accept";

            canvasDiv.appendChild(canvasElement);
            buttonsContainer.appendChild(buttonClear);
            //buttonsContainer.appendChild(buttonAccept);

            signatureArea.className = "signatureArea";
            signatureArea.appendChild(labelDiv);
            signatureArea.appendChild(canvasDiv);
            signatureArea.appendChild(buttonsContainer);

            document.getElementById(containerId).appendChild(signatureArea);
        }

        function pointerDown(evt) {
            ctx.beginPath();
            ctx.moveTo(evt.offsetX, evt.offsetY);
            canvas.addEventListener("mousemove", paint, false);
        }

        function pointerUp(evt) {
            canvas.removeEventListener("mousemove", paint);
            paint(evt);
        }

        function paint(evt) {
            ctx.lineTo(evt.offsetX, evt.offsetY);
            ctx.stroke();
        }

        function wireButtonEvents() {
            var btnClear = document.getElementById("btnClear");
                /*btnAccept = document.getElementById("btnAccept");*/
            btnClear.addEventListener("click", function () {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
            }, false);
            //btnAccept.addEventListener("click", function () {
            //    callback();
            //}, false);
        }

        function getSignatureImage() {
            return ctx.getImageData(0, 0, canvas.width, canvas.height).data;
        }

        return {
            init: initCotnrol,
            getSignatureImage: getSignatureImage
        };
    }
})(this.ns = this.ns || {});
