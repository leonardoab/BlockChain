export class BaseEntityDescription {
    public description?: string;
}

export class BaseEntity<T> extends BaseEntityDescription {
    public id?: T;
}
