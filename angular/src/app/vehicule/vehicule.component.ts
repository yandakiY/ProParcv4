import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { BookService, BookDto, bookTypeOptions } from '@proxy/books';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { VehiculeDto, VehiculeService } from '@proxy/vehicules';
import { map } from 'rxjs';

@Component({
  selector: 'app-book',
  templateUrl: './vehicule.component.html',
  styleUrls: ['./vehicule.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class VehiculeComponent implements OnInit {
  vehicule = { items: [], totalCount: 0 } as PagedResultDto<VehiculeDto>;

  selectedVehicule = {} as VehiculeDto; // declare selectedBook

  form: FormGroup;

  bookTypes = bookTypeOptions;

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private bookService: BookService,
    private vehiculeService: VehiculeService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {}

  ngOnInit() {
    const vehiculeStreamCreator = (query) => this.vehiculeService.getAll(query).pipe(
      map((response: VehiculeDto[]) => ({
        items: response,
        totalCount: response.length
      }))
    );

    this.list.hookToQuery(vehiculeStreamCreator).subscribe((response) => {
      this.vehicule = response;
    });
  }

  createVehicule() {
    this.selectedVehicule = {} as VehiculeDto; // reset the selected book
    this.buildForm();
    this.isModalOpen = true;
  }

  editVehicule(id: string) {

    this.vehiculeService.getByIdById(id).subscribe((vehicule) => {
      this.selectedVehicule = {id: id,...vehicule};
      console.log("selectedVehicule", this.selectedVehicule);
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.vehiculeService.deleteById(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm(): void {
    this.form = this.fb.group({
      matricule: [this.selectedVehicule.matricule || '', [Validators.required]],
      marque: [this.selectedVehicule.marque || '', [Validators.required]],
      dateFabrication: [this.selectedVehicule.dateFabrication ? new Date(this.selectedVehicule.dateFabrication) : null,
        Validators.required,]
    });
  }

  // change the save method
  save() {
    if (this.form.invalid) {
      return;
    }

    console.log("form value", this.form.value);

    const request = this.selectedVehicule.id
      ? this.vehiculeService.updateByVehicule({id: this.selectedVehicule.id,...this.form.value})
      : this.vehiculeService.createByVehicule(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
