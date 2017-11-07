import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import {SigninComponent} from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import {AppRoutingModule} from './app-routing.module';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { SliderComponent } from './components/slider/slider.component';
import {PageSliderModule} from 'ng2-page-slider';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { FrameComponent } from './components/slider/frame/frame.component';
import { UserPurchaseHistoryComponent } from './components/user-purchase-history/user-purchase-history.component';
import { ShortenPipe } from './pipes/shorten.pipe';
import { BenefitsByCategoryComponent } from './components/benefits-by-category/benefits-by-category.component';
import {BenefitsByCqategoryService} from './components/benefits-by-category/benefits-by-category.service';
import {ModalModule} from 'ng2-modal';
import { PopupModalComponent } from './modals/popup-modal/popup-modal.component';
import { ConfirmPasswordModalComponent } from './modals/confirm-password-modal/confirm-password-modal.component';
import {PictureGridComponent} from './components/picture-grid/picture-grid.component';
import {ModalService} from './modals/modal.service';
import { MailPasswordModalComponent } from './modals/mail-password-modal/mail-password-modal.component';
import { AgreementModalComponent } from './modals/agreement-modal/agreement-modal.component';
import { SuccessModalComponent } from './modals/success-modal/success-modal.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SigninComponent,
    SignupComponent,
    HeaderComponent,
    FooterComponent,
    SliderComponent,
    FrameComponent,
    PictureGridComponent,
    UserPurchaseHistoryComponent,
    ShortenPipe,
    BenefitsByCategoryComponent,
    PopupModalComponent,
    ConfirmPasswordModalComponent,
    MailPasswordModalComponent,
    AgreementModalComponent,
    SuccessModalComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    PageSliderModule,
    BrowserAnimationsModule,
    ModalModule
  ],
  providers: [BenefitsByCqategoryService, ModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
