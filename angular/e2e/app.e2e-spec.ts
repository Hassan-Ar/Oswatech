import { OswatechTemplatePage } from './app.po';

describe('Oswatech App', function() {
  let page: OswatechTemplatePage;

  beforeEach(() => {
    page = new OswatechTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
