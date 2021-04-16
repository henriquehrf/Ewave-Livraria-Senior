export interface Credencial {
    authenticated: boolean,
    created: Date,
    expiration: Date,
    acessToken: string
}