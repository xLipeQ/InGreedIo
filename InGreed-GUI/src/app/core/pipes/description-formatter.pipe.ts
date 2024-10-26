import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'descriptionFormatter',
    standalone: true,
})
export class DescriptionFormatterPipe implements PipeTransform {
    transform(description: string): string {
        return description.substring(0, 150) + "..."
    }
}