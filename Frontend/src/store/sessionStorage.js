const KEY = 'HATED_APP_KEY';

class SessionStorageHandler {
  constructor() {
    this.storage = sessionStorage;
  }
  removeState() {
    this.storage.removeItem(KEY);
  }
  saveState(toSave) {
    this.storage.setItem(KEY, JSON.stringify(toSave));
  }
  getState() {
    return JSON.parse(this.storage.getItem(KEY));
  }
  isLogged() {
    return !!this.storage.getItem(KEY);
  }
}

export default new SessionStorageHandler();
