import { EmxPage } from './app.po';

describe('emx App', () => {
  let page: EmxPage;

  beforeEach(() => {
    page = new EmxPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
