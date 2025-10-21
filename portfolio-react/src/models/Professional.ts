// Professional and About models

export enum Language {
  Spanish = 'Spanish',
  English = 'English',
}

export interface Professional {
  id: number;
  language: Language;
  role: string;
  name: string;
  professionalProfile: string;
  interests: Interest[];
  experiences: Experience[];
  additionalInfo: Detail[];
  tools: Tool[];
  trainings: Training[];
  contact?: Contact;
}

export interface Interest {
  id: number;
  professionalId: number;
  name: string;
  categoryId: number;
  category?: Category;
}

export interface Detail {
  id: number;
  professionalId: number;
  value: string;
}

export interface Skill {
  id: number;
  experienceId: number;
  value: string;
}

export interface Experience {
  id: number;
  professionalId: number;
  name: string;
  role: string;
  skills: Skill[];
  yearStart: number;
  yearFinish?: number;
}

export interface Category {
  id: number;
  name: string;
  description: string;
}

export interface Tool {
  id: number;
  professionalId: number;
  name: string;
  description: string;
  logoUrl: string;
}

export interface Training {
  id: number;
  professionalId: number;
  accademy: string;
  speciality: string;
  yearStart: number;
  yearFinish?: number;
}

export interface Contact {
  id: number;
  professionalId: number;
  phoneNumber: string;
  email: string;
  linkedIn: string;
  github: string;
  city: string;
}
