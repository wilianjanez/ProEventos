import { Component } from '@angular/core';
import { CollapseModule } from 'ngx-bootstrap/collapse';

@Component({
  selector: 'app-nav',
  standalone: true,
  templateUrl: './nav.component.html',
  imports: [CollapseModule],
})
export class NavComponent {
  isCollapsed = false;
}
