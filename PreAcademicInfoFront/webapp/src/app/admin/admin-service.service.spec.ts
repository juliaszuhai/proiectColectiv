import { TestBed } from '@angular/core/testing';

import { AdminServiceService } from './admin-service.service';

export interface User{
  username: string;
  nume: string;
  prenume: string;
  type: string;
  cnp: string;
}


describe('AdminServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AdminServiceService = TestBed.get(AdminServiceService);
    expect(service).toBeTruthy();
  });
});
