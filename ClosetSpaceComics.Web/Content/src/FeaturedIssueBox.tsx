import * as React from "react";
import * as ReactDOM from "react-dom";
import {FeaturedIssueModel, IAppState} from "./Models";

export class FeaturedIssueBox extends React.Component<any, IAppState>{
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
            var tmp: IAppState = this.state;
            tmp.items = dataItems;
            this.setState(tmp);
        }.bind(this);
        xhr.send();
    }

    render() {
        return (
            <div>test</div>
        )
    }
}
