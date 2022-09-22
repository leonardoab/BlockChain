import { Component, OnInit } from '@angular/core';
import { CarteiraService } from './carteira.service';
import { Router } from "@angular/router";
import { Carteira } from '../model/Carteira';

@Component({
  selector: 'app-carteira',
  templateUrl: './carteira.component.html',
  styleUrls: ['./carteira.component.scss']
})
export class CarteiraComponent implements OnInit {
  carteiras?: Carteira[];

  constructor(private router: Router, private service: CarteiraService) { }

  ngOnInit() {
    this.service.getTodasCarteira().subscribe((data) => (this.carteiras = data));
}

}
