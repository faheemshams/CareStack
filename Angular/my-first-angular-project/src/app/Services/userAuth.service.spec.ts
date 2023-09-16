import { TestBed } from '@angular/core/testing';

import { UserAuthService } from './userAuth.service';

describe('LocalstorageService', () => {
  let service: UserAuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserAuthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
