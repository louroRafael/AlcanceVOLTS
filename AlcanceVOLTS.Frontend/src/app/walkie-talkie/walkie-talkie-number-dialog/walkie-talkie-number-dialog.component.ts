import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-walkie-talkie-number-dialog',
  templateUrl: './walkie-talkie-number-dialog.component.html',
  styleUrls: ['./walkie-talkie-number-dialog.component.scss']
})
export class WalkieTalkieNumberDialogComponent implements OnInit {

  numbers: number[];

  constructor(
  ) { }

  ngOnInit(): void {
    this.numbers = Array(30).fill(1).map((x, i) => i + 1);
  }

}
