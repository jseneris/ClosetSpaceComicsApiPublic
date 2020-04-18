"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
class FeaturedIssueBox extends React.Component {
    constructor(state) {
        super(state);
        this.state = { items: null, showPopUp: false };
        this.loadFromServer();
    }
    loadFromServer() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', 'getissues', true);
        xhr.onload = function () {
            var dataItems = JSON.parse(xhr.responseText);
            var tmp = this.state;
            tmp.items = dataItems;
            this.setState(tmp);
        }.bind(this);
        xhr.send();
    }
    render() {
        return (React.createElement("div", null, "test"));
    }
}
exports.FeaturedIssueBox = FeaturedIssueBox;
//# sourceMappingURL=FeaturedIssueBox.js.map