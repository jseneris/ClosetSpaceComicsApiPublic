export interface FeaturedIssueModel {
    Id: number;
    Name: string;
    Description: string;
    Picture: string;
}

export interface IAppState {
    items: FeaturedIssueModel[];
    showPopup: boolean;
}
