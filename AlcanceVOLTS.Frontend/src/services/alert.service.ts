import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private modalService: NgbModal) { }

  showLoading(message: string = "") {
    swal.fire({
      title: '<span>Só um minutinho...</span>',
      html: `<img class="loading-gif" src="assets/images/loading.gif" alt="Loading">
              <div class="progress-bar-container">
                <div class="progress-bar"></div>
              </div>`,
      allowOutsideClick: false,
      showConfirmButton: false,
    });
  }

  hideLoading() {
    swal.close();
  }
}
