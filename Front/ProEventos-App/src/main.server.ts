import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config'; // USE o appConfig corrigido

const bootstrap = () => bootstrapApplication(AppComponent, appConfig);

export default bootstrap;
